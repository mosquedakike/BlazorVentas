using AplicacionVentas.Server.Helpers;
using AplicacionVentas.Shared.Entidades;
using AplicacionVentas.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AplicacionVentas.Client.Shared;
using System.ComponentModel.DataAnnotations;

namespace AplicacionVentas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN, VENDEDOR")]
    public class EvidenciasController: ControllerBase
    {
        private readonly AplicacionVentasContext context;
        private readonly IAlmacenadorArchivos almacenadorDeArchivos;
        private readonly string contenedor = "evidencias";

        public EvidenciasController(AplicacionVentasContext context,
            IAlmacenadorArchivos almacenadorDeArchivos)
        {
            this.context = context;
            this.almacenadorDeArchivos = almacenadorDeArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<List<EntidadEvidencia>>> Get()
        {
            return await context.Evidencias.Include(ev => ev.Empleado).ToListAsync();
            //return  await context.Evidencias.ToListAsync();
        }

        [AllowAnonymous]
        [HttpGet("filtrar")]
        public async Task<ActionResult<List<EntidadEvidencia>>> Get([FromQuery] ParametrosBusquedaEvidencias parametrosBusqueda)
        {
            var evidenciasQueryable = context.Evidencias.Include(x => x.Empleado)
                .ThenInclude(y => y.Proyecto).AsQueryable();

            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.nombre))
            {
                evidenciasQueryable = evidenciasQueryable
                    .Where(x => x.Empleado.NombreEmpleado.ToUpper()
                    .Contains(parametrosBusqueda.nombre.ToUpper()));
            }

            if (parametrosBusqueda.proyectoId != 0)
            {
                evidenciasQueryable = evidenciasQueryable
                    .Where(x => x.Empleado.Proyecto.ProyectoId.ToString()
                    .Contains(parametrosBusqueda.proyectoId.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.fechaInicio)
                    && !string.IsNullOrWhiteSpace(parametrosBusqueda.fechaFin))
            {
                DateTime fechaInicio = DateTime.Parse(parametrosBusqueda.fechaInicio);
                DateTime fechaFin = DateTime.Parse(parametrosBusqueda.fechaFin)
                    .AddHours(23).AddMinutes(59).AddSeconds(59);

                evidenciasQueryable = evidenciasQueryable
                .Where(x => x.FechaCaptura
                >= fechaInicio && x.FechaCaptura <= fechaFin);
            }

            await HttpContext.InsertarParametrosPaginacionEnRespuesta(evidenciasQueryable,
                parametrosBusqueda.CantidadRegistros);

            var evidencias = await evidenciasQueryable.Paginar(parametrosBusqueda.Paginacion).ToListAsync();

            return evidencias;
        }        

        public class ParametrosBusquedaEvidencias
        {
            public int Pagina { get; set; } = 1;
            public int CantidadRegistros { get; set; } = 10;

            public PaginacionDTO Paginacion
            {
                get { return new PaginacionDTO() { Pagina = Pagina, CantidadRegistros = CantidadRegistros }; }
            }

            public string nombre { get; set; }
            public int proyectoId { get; set; }

            public string fechaInicio { get; set; }
            public string fechaFin { get; set; }
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(EntidadEvidencia evidencia)
        {
            if (!string.IsNullOrWhiteSpace(evidencia.Foto))
            {
                var fotoEvidencia = Convert.FromBase64String(evidencia.Foto);
                evidencia.Foto = await almacenadorDeArchivos.GuardarArchivo(fotoEvidencia, ".jpg", contenedor);
            }

            context.Add(evidencia);
            await context.SaveChangesAsync();
            return evidencia.EvidenciaId;
        }
    }
}

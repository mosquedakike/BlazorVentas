using AplicacionVentas.Server.Helpers;
using AplicacionVentas.Shared.DTOs;
using AplicacionVentas.Shared.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionVentas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ADMIN")]
    public class EmpleadosController : ControllerBase
    {
        private readonly AplicacionVentasContext context;

        public EmpleadosController(AplicacionVentasContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<EntidadEmpleado>>> Get([FromQuery] PaginacionDTO paginacion,
            [FromQuery] string nombre, [FromQuery] string paterno)
        {
            var queryable = context.Empleados.Include(x => x.Proyecto).AsQueryable();
            if (!string.IsNullOrEmpty(nombre))
            {
                queryable = queryable.Where(x => x.NombreEmpleado.Contains(nombre));
            }
            if (!string.IsNullOrEmpty(paterno))
            {
                queryable = queryable.Where(x => x.ApPaterno.Contains(paterno));
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }

        [HttpGet("lista")]
        //[AllowAnonymous]
        public async Task<ActionResult<List<EntidadEmpleado>>> Get()
        {
            return await context.Empleados.ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<EntidadEmpleado>> Get(int id)
        {
            return await context.Empleados.FirstOrDefaultAsync(x => x.EmpleadoId == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(EntidadEmpleado empleado)
        {
            context.Add(empleado);
            await context.SaveChangesAsync();
            return empleado.EmpleadoId;
        }

        [HttpPut]
        public async Task<ActionResult> Put(EntidadEmpleado empleado)
        {
            context.Attach(empleado).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}

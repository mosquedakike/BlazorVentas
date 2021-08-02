using AplicacionVentas.Shared.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AplicacionVentas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProyectosController: ControllerBase
    {
        private readonly AplicacionVentasContext context;
        public ProyectosController(AplicacionVentasContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<EntidadProyecto>>> Get()
        {
            return await context.Proyectos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntidadProyecto>> Get(int id)
        {
            return await context.Proyectos.FirstOrDefaultAsync(x => x.ProyectoId == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(EntidadProyecto proyecto)
        {
            context.Add(proyecto);
            await context.SaveChangesAsync();
            return proyecto.ProyectoId;
        }

        [HttpPut]
        public async Task<ActionResult> Put(EntidadProyecto proyecto)
        {
            context.Attach(proyecto).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}

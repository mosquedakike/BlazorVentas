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
    public class ClientesController: ControllerBase
    {
        private readonly AplicacionVentasContext context;

        public ClientesController(AplicacionVentasContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<EntidadCliente>>> Get()
        {
            return await context.Clientes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntidadCliente>> Get(int id)
        {
            return await context.Clientes.FirstOrDefaultAsync(x => x.ClienteId == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(EntidadCliente cliente)
        {
            context.Add(cliente);
            await context.SaveChangesAsync();
            return cliente.ClienteId;
        }

        [HttpPut]
        public async Task<ActionResult> Put(EntidadCliente cliente)
        {
            context.Attach(cliente).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}

using AplicacionVentas.Shared.Entidades;
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
    public class VentasController: ControllerBase
    {
        private readonly AplicacionVentasContext context;
        public VentasController(AplicacionVentasContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<EntidadVenta>>> Get()
        {
            return await context.Ventas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(EntidadVenta venta)
        {
            context.Add(venta);
            await context.SaveChangesAsync();
            return venta.VentaId;
        }
    }
}

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
    public class VentasTotalController
    {
        private readonly AplicacionVentasContext context;
        public VentasTotalController(AplicacionVentasContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<EntidadVentaTotal>>> Get()
        {
            return await context.VentasTotal.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(EntidadVentaTotal ventaTotal)
        {
            context.Add(ventaTotal);
            await context.SaveChangesAsync();
            return ventaTotal.VentaTotalId;
        }
    }
}

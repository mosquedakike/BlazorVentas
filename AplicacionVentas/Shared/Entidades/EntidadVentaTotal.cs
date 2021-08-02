using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVentas.Shared.Entidades
{
    public class EntidadVentaTotal
    {
        [Key]
        public int VentaTotalId { get; set; }

        public int EmpleadoId { get; set; }

        public EntidadEmpleado Empleado { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime? FechaVenta { get; set; }

        public DateTime FechaCaptura { get; set; }
    }
}

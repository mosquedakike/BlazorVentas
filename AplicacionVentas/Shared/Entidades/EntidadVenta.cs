using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVentas.Shared.Entidades
{
    public class EntidadVenta
    {
        [Key]
        public int VentaId { get; set; }

        //Relacion con EntidadEmpleado
        [Required(ErrorMessage = "El campo es requerido")]
        public int EmpleadoId { get; set; }

        public EntidadEmpleado Empleado { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string DescripcionProducto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime? FechaVenta { get; set; }

        public DateTime FechaCaptura { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVentas.Shared.Entidades
{
    public class EntidadEmpleado
    {
        [Key]
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(30)]
        public string NombreEmpleado { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(30)]
        public string ApPaterno { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(30)]
        public string ApMaterno { get; set; }

        //Relacion con EntidadCliente
        public int ProyectoId { get; set; }

        public EntidadProyecto Proyecto { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string PuestoEmpleado { get; set; }

        public bool Estatus { get; set; }

        //Relacion con EntidadVentas
        public ICollection<EntidadVenta> Ventas { get; set; }

        public ICollection<EntidadVentaTotal> VentasTotal { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVentas.Shared.Entidades
{
    public class EntidadProyecto
    {
        [Key]
        public int ProyectoId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string NombreProyecto { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Municipio { get; set; }

        public bool Estatus { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public int ClienteId { get; set; }
        
        public EntidadCliente Cliente { get; set; }

        //public ICollection<EntidadEmpleado> Empleado { get; set; }
    }
}

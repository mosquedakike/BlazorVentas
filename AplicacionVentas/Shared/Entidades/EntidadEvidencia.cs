using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVentas.Shared.Entidades
{
    public class EntidadEvidencia
    {
        [Key]
        public int EvidenciaId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Foto { get; set; }

        public DateTime? FechaCaptura { get; set; }

        public int EmpleadoId { get; set; }

        public EntidadEmpleado Empleado { get; set; }
    }
}

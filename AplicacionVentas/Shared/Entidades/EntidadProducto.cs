using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVentas.Shared.Entidades
{
    public class EntidadProducto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(80)]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(600)]
        public string DescripcionProducto { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Marca { get; set; }

        public bool Estatus { get; set; }
    }
}

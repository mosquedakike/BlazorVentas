 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVentas.Shared.Entidades
{
    public class EntidadCliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage ="El campo es requerido")]
        [StringLength(100)]
        public string NombreCliente { get; set; }

        public bool Estatus { get; set; }

        //Relacion con SaleDetails
        public ICollection<EntidadProyecto> Proyectos { get; set; }
    }
}

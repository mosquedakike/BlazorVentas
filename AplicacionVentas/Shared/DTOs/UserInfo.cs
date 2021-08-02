using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionVentas.Shared.DTOs
{
    public class UserInfo
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        public string Password { get; set; }
    }
}

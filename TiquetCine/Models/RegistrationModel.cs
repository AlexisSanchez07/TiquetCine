using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiquetCine.Models
{
    public class RegistrationModel
    {
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Numero de Telefono")]
        public string Mobile { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Precio")]
        public decimal Amount { get; set; }
    }
}

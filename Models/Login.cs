using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterTimesContext.Models
{
    public class Login
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Nome Obrigatório")]
        public string Nome {  get; set; }

        [Required (ErrorMessage = "Senha Obrigatória.")]
        public string Senha { get; set; }


    }
}

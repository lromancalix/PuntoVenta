using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Request
{
    public class RequestMarca
    {
        public int idMarca { get; set; } = 0;
        [Required(ErrorMessage = "La marca es requerida.")]
        public string marca { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string imagen { get; set; } = "";


    }
}

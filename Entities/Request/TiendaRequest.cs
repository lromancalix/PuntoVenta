using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Request
{
    public class TiendaRequest
    {
        [Required(ErrorMessage ="El idTienda es requerido.")]
        public int idTienda { get; set; }
        [Required(ErrorMessage = "La tienda es requerida.")]
        public string tienda { get; set; }

        public string imagen { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Response
{
    public class TiendaResponse: Estatus
    {
        public int idTienda { get; set; }
        public string tienda { get; set; }
        public string imagen { get; set; }
    }
}

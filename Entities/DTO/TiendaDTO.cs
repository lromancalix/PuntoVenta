using System;
using System.Collections.Generic;
using System.Text;
using UtilitiesCLX.Attributes;

namespace Entities.DTO
{
    public class TiendaDTO
    {
        [DataNames("idTienda", "idTienda")]
        public int idTienda { get; set; }
        [DataNames("tienda", "tienda")]
        public string tienda { get; set; }
        [DataNames("activo","activo")]
        public bool activo { get; set; }
        [DataNames("imagen","imagen")]
        public string imagen { get; set; }
    }
}

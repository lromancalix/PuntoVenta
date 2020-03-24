using System;
using System.Collections.Generic;
using System.Text;
using UtilitiesCLX.Attributes;

namespace Entities.DTO
{
    public class MarcaDTO : EstatusDTO
    {
        [DataNames("idMarca", "idMarca")]
        public int idMarca { get; set; }
        [DataNames("marca", "marca")]
        public string marca { get; set; }

        [DataNames("correo", "correo")]
        public string correo { get; set; } = "";
        [DataNames("telefono", "telefono")]
        public string telefono { get; set; }
        [DataNames("direccion", "direccion")]
        public string direccion { get; set; } = "";
        [DataNames("imagen", "imagen")]
        public string imagen { get; set; } = "";
        public DateTime fechaCreacion { get; set; }
    }
}

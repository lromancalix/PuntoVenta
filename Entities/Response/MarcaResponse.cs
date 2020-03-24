using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Response
{
    public class MarcaResponse: Estatus
    {
        public int idMarca { get; set; }

        public string marca { get; set; }

        public string imagen { get; set; }

    }

    public class DetallesMarcaResponse: Estatus
    {
        public int idMarca { get; set; }
        public string marca { get; set; }
        public string imagen { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string direccion { get; set; }
    }
}

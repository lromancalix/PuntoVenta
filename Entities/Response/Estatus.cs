using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Response
{
    public class Estatus
    {
        public string estatus { get; set; } = "";
        public string descripcion { get; set; } = "";

        public bool _error { get; set; } = false;
    }
}

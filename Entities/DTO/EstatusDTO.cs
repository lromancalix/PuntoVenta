using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class EstatusDTO
    {
        public string estatus { get; set; } = "OK";
        public string descripcion { get; set; } = "";

        public bool _error { get; set; } = false;

    }
}

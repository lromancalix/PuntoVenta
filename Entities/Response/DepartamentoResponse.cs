using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Response
{
    public class DepartamentoResponse : Estatus
    {
        public int idDepartamento { get; set; }
        public string departamento { get; set; }
    }
}

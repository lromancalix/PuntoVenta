using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Request
{
    public class DepartamentoRequest
    {
        public int idDepartamento { get; set; } = 0;
        [Required(ErrorMessage ="El departamento es requerido.")]
        public string departamento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contratos
{
    public interface ICrud<T> 
    {
        Task<T> Guardar(T entidad);
        //Task<T> Actualizar(T entidad);

        Task<List<T>> Obtener(int? id = 0);

        //Task<T> ObtenerPorId(int id);

        Task<bool> Eliminar(int id);

    }
}

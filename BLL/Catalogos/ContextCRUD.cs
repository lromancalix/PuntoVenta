using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Catalogos
{
    public class ContextCRUD<T> : Contratos.ICrud<T>
    {
        Contratos.ICrud<T> _iCrud;

        public ContextCRUD(Contratos.ICrud<T> crud)
        {
            this._iCrud = crud;
        }

        public async Task<bool> Eliminar(int id)
        {
            return await this._iCrud.Eliminar(id);
        }

        public async Task<T> Guardar(T entidad)
        {
            return await this._iCrud.Guardar(entidad);
        }

        public async Task<List<T>> Obtener(int? id = 0)
        {
            return await this._iCrud.Obtener(id);
        }
    }
}

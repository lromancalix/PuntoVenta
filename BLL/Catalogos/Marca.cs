using DAL;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UtilitiesCLX.Mapping;

namespace BLL.Catalogos
{
    public class Marca : Contratos.ICrud<MarcaDTO>
    {
        ApiConfig _config;
        private readonly ISQLCmdConfig _sQLCmdConfig;

        public Marca(ApiConfig config)
        {
            this._config = config;
            this._sQLCmdConfig = new SQLCmdConfig()
            {
                connectioString = this._config.connectionString
            };
        }

        #region DELETE

        public async Task<bool> Eliminar(int id)
        {

            try
            {

                this._sQLCmdConfig.spName = "EliminarMarca";
                this._sQLCmdConfig.sqlParameter = new List<SqlParameter>()
            {
                new SqlParameter("@idMarca", id),

            };

                DataTable tabla = await new DBOperation(this._sQLCmdConfig).getValue();

                if (tabla.Rows.Count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {

                throw;
            }


        }

        #endregion

        #region SAVE

        //public async Task<MarcaDTO> Actualizar(MarcaDTO entidad)
        //{
        //    return await this.Guardar(entidad);
        //}

        public async Task<MarcaDTO> Guardar(MarcaDTO entidad)
        {
            try
            {


                this._sQLCmdConfig.spName = "GuardarMarca";
                this._sQLCmdConfig.sqlParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idMarca", entidad.idMarca),
                    new SqlParameter("@marca", entidad.marca),
                    new SqlParameter("@correo", entidad.correo),
                    new SqlParameter("@telefono", entidad.telefono),
                    new SqlParameter("@direccion", entidad.direccion),
                    new SqlParameter("@imagen", entidad.imagen),

                };

                DataTable tabla = await new DBOperation(this._sQLCmdConfig).getValue();

                DataNamesMapper<MarcaDTO> mapper = new DataNamesMapper<MarcaDTO>();

                var response = mapper.Map(tabla).ToList().FirstOrDefault();

                return response;

            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region GET

        //public async Task<MarcaDTO> ObtenerPorId(int id)
        //{
        //    List<MarcaDTO> response = await this.ObtenerTodos(id);
        //    return response.FirstOrDefault();
        //}

        public async Task<List<MarcaDTO>> Obtener(int? id = 0)
        {
            try
            {

                this._sQLCmdConfig.spName = "ObtenerMarca";
                this._sQLCmdConfig.sqlParameter = this.ObtenerParametros(id);

                

                DataTable tabla = await new DBOperation(this._sQLCmdConfig).getValue();

                DataNamesMapper<MarcaDTO> mapper = new DataNamesMapper<MarcaDTO>();

                var response = mapper.Map(tabla).ToList();

                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        private List<SqlParameter> ObtenerParametros(int? id = 0)
        {
            if (id == 0)
            {
                return new List<SqlParameter>();
            }
            else
            {
                return new List<SqlParameter>()
                {
                     new SqlParameter("@idMarca",id)
                };
            }
        }


    }
}

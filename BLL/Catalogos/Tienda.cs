using DAL;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesCLX.Mapping;

namespace BLL.Catalogos
{
    public class Tienda : Contratos.ICrud<TiendaDTO>
    {
        ApiConfig _config;
        private readonly ISQLCmdConfig _sQLCmdConfig;

        public Tienda(ApiConfig config)
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

                this._sQLCmdConfig.spName = "EliminarTienda";
                this._sQLCmdConfig.sqlParameter = new List<SqlParameter>()
            {
                new SqlParameter("@idTienda", id),

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

        public async Task<TiendaDTO> Guardar(TiendaDTO entidad)
        {
            try
            {


                this._sQLCmdConfig.spName = "GuardarMarca";
                this._sQLCmdConfig.sqlParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idTienda", entidad.idTienda),
                    new SqlParameter("@tienda", entidad.tienda),
                    new SqlParameter("@imagen", entidad.imagen)

                };

                DataTable tabla = await new DBOperation(this._sQLCmdConfig).getValue();

                DataNamesMapper<TiendaDTO> mapper = new DataNamesMapper<TiendaDTO>();

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

        public async Task<List<TiendaDTO>> Obtener(int? id = 0)
        {
            try
            {

                this._sQLCmdConfig.spName = "ObtenerTienda";
                this._sQLCmdConfig.sqlParameter = this.ObtenerParametros(id);



                DataTable tabla = await new DBOperation(this._sQLCmdConfig).getValue();

                DataNamesMapper<TiendaDTO> mapper = new DataNamesMapper<TiendaDTO>();

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
                     new SqlParameter("@idTienda",id)
                };
            }
        }

    }
}

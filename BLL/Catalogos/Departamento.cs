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
    public class Departamento : Contratos.ICrud<DepartamentoDTO>
    {
        ApiConfig _config;
        private readonly ISQLCmdConfig _sQLCmdConfig;

        public Departamento(ApiConfig config)
        {
            this._config = config;
            this._sQLCmdConfig = new SQLCmdConfig()
            {
                connectioString = this._config.connectionString
            };
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {

                this._sQLCmdConfig.spName = "EliminarDepto";
                this._sQLCmdConfig.sqlParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idDepto", id),

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

        public async Task<DepartamentoDTO> Guardar(DepartamentoDTO entidad)
        {
            try
            {


                this._sQLCmdConfig.spName = "GuardarDepto";
                this._sQLCmdConfig.sqlParameter = new List<SqlParameter>()
                {
                    new SqlParameter("@idDepartamento", entidad.idDepartamento),
                    new SqlParameter("@departamento", entidad.departamento)

                };

                DataTable tabla = await new DBOperation(this._sQLCmdConfig).getValue();

                DataNamesMapper<DepartamentoDTO> mapper = new DataNamesMapper<DepartamentoDTO>();

                var response = mapper.Map(tabla).ToList().FirstOrDefault();

                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<DepartamentoDTO>> Obtener(int? id = 0)
        {
            try
            {

                this._sQLCmdConfig.spName = "ObtenerDepartamento";
                this._sQLCmdConfig.sqlParameter = this.ObtenerParametros(id);



                DataTable tabla = await new DBOperation(this._sQLCmdConfig).getValue();

                DataNamesMapper<DepartamentoDTO> mapper = new DataNamesMapper<DepartamentoDTO>();

                var response = mapper.Map(tabla).ToList();

                return response;

            }
            catch (Exception)
            {

                throw;
            }
        }

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
                     new SqlParameter("@idDepto",id)
                };
            }
        }



    }
}

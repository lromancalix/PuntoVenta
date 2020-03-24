using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL
{
    public class DBOperation
    {
        private readonly SqlCommand _sqlCommand;
        private readonly DataTable _tabla;

        private readonly ISQLCmdConfig _ISQLCmdConfig;
        public DBOperation(ISQLCmdConfig appConfiguration)
        {
            this._ISQLCmdConfig = appConfiguration;
            this._tabla = new DataTable();

        }

        private async Task EjecutaCommand()
        {

            try
            {

                using (SqlConnection conn = new SqlConnection(this._ISQLCmdConfig.connectioString))
                {
                    using (SqlCommand cmd = new SqlCommand(this._ISQLCmdConfig.spName, conn))
                    {
                        cmd.CommandType = this._ISQLCmdConfig.sqlCommanType;

                        conn.Open();

                        cmd.Parameters.AddRange(this._ISQLCmdConfig.sqlParameter.ToArray());

                        SqlDataReader dr = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);

                        this._tabla.Load(dr);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<DataTable> getValue()
        {
            await this.EjecutaCommand();
            return this._tabla;
        }

    }


}

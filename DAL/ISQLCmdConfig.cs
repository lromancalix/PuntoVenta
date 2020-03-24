using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public interface ISQLCmdConfig
    {
        string connectioString { get; set; }
        string spName { get; set; }
        CommandType sqlCommanType { get; set; }
        List<SqlParameter> sqlParameter { get; set; }
    }
}
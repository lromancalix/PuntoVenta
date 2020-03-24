using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class SQLCmdConfig : ISQLCmdConfig
    {
        public List<SqlParameter> sqlParameter { get; set; }
        public string connectioString { get; set; }

        public string spName { get; set; }
        public CommandType sqlCommanType { get; set; } = CommandType.StoredProcedure;
    }
}

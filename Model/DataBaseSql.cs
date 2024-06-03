using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Model
{
    public sealed class DataBaseSql
    {
        private static readonly Lazy<DataBaseSql> instance = new Lazy<DataBaseSql>(() => new DataBaseSql());

        readonly string _connectionString = "Data Source=127.0.0.1; Initial Catalog=Radar; " +
            "User Id=sa; Password=SqlServer2019!; TrustServerCertificate=true;";

        private readonly SqlConnection _conn;


        private DataBaseSql()
        {
            _conn = new SqlConnection(_connectionString);            
        }

        public static DataBaseSql Instance => instance.Value;

        public SqlConnection GetConnection()
        {
            if(_conn.State == System.Data.ConnectionState.Closed)
            {
                _conn.Open();
            }
            return _conn;
        }
        public void Close()
        {

           if (_conn.State == System.Data.ConnectionState.Open)
           {
                _conn.Close();
           }
            
        }
    }
}

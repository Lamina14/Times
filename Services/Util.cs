using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace MasterTimesContext.Services
{
    public class Util
    {
        private readonly IConfiguration _configuration;

        public Util(IConfiguration configuration)
        {
            this._configuration = configuration;
        }



        public DataTable ReturnDataTableSqlServer(string sql)
        {
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DevConnection"));
            using (conn)
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    IDataReader dtreader = cmd.ExecuteReader();
                    DataTable dtresult = new DataTable();
                    dtresult.Load(dtreader);
                    conn.Close();
                    return dtresult;
                }
            }
        }

        public int ExecuteSqlSqlServer(string sql)
        {
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DevConnection"));
            using (conn)
            {
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result;
                }
            }
        }

    }
}

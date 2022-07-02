using System.Configuration;
using System.Data.SqlClient;

namespace OOP
{
    internal static class Connection
    {
        /// <summary>
        /// Connection configuration to database
        /// </summary>
        public static SqlConnection conn = new
        SqlConnection(ConfigurationManager.ConnectionStrings["Model1"].ConnectionString);
    }
}
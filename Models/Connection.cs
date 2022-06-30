using System.Configuration;
using System.Data.SqlClient;

namespace OOP
{
    internal static class Connection
    {
        public static SqlConnection conn = new
        SqlConnection(ConfigurationManager.ConnectionStrings["hoteldbEntities"].ConnectionString);
    }
}
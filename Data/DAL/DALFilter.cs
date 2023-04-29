
using System.Data.SqlClient;
using System.Data;

namespace Hypnos.Data.DAL
{
    public class DALFilter
    {
        public static string? Excep { get; set; }
        public static void GetError(string Err)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("U_SP_StoreError", con);
            cmd.Parameters.AddWithValue("@Err", Err);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

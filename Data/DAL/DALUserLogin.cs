using System.Data.SqlClient;
using System.Data;
using Hypnos.Data.Entities;

namespace Hypnos.Data.DAL
{
    public class DALUserLogin
    {
        public static string? Excep { get; set; }

        public static List<EntUserLogin> GetUserByName(string? UserName)
        {
            List<EntUserLogin> list = new List<EntUserLogin>();

            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_GetUserByName", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EntUserLogin ee = new EntUserLogin();
                   // ee.UserId = sdr["userId"].ToString();
                    ee.UserName = sdr["UserName"].ToString();
                    ee.Password = sdr["Password"].ToString();
                    ee.Name = sdr["Name"].ToString();

                    list.Add(ee);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DAL.DALFilter.GetError(Excep);
            }
            return list;

        }

        public static void SaveSignUp(EntUserLogin ee)
        {
            try
            {

                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_SaveSignUp", con);
                cmd.Parameters.AddWithValue("@UserName", ee.UserName);
                cmd.Parameters.AddWithValue("@Password", ee.Password);
                
                cmd.Parameters.AddWithValue("@Name", ee.Name);
                cmd.Parameters.AddWithValue("@BMI", ee.BMI);
                cmd.Parameters.AddWithValue("@Height", ee.Height);
                cmd.Parameters.AddWithValue("@Weight", ee.Weight);
                cmd.Parameters.AddWithValue("@Neck_Circumference", ee.Neck_Circumference);
                cmd.Parameters.AddWithValue("@Address", ee.Address);
                cmd.Parameters.AddWithValue("@DOB", ee.DOB);
                cmd.Parameters.AddWithValue("@Pharmacy", ee.Pharmacy);
                cmd.Parameters.AddWithValue("@Payment_Info", ee.Payment_Info);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
                DAL.DALFilter.GetError(Excep);
            }
        }

        public static void UpdatePassword(String? UserId, String? Password)
        {
            try
            {


                SqlConnection con = DBHelper.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("U_SP_UpdatePassword", con);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Excep = ex.Message.ToString() + ex.StackTrace.ToString();
               DAL.DALFilter.GetError(Excep);
            }
        }

    }
}

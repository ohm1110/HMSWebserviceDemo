using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace HotelRegistration
{
    /// <summary>
    /// Summary description for HotelRegistration
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HotelRegistration : System.Web.Services.WebService
    {

        public HotelRegistration()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void InsertHotelInfo(string HotelName, string UniqKey, string UserName, string Password)
        {
            string dbconnection = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(dbconnection);
            SqlCommand cmd1 = new SqlCommand("select * from HotelRegistration", conn);
            conn.Open();


            SqlDataReader dr = cmd1.ExecuteReader();
            int HotelID = 0;

            while (dr.Read())
            {

                HotelID = dr.GetInt32(0);


            }
            HotelID = HotelID + 1;
            conn.Close();


            using (SqlConnection con = new SqlConnection(dbconnection))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO HotelRegistration(HotelID,HotelName,UniqKey,UserName,Password,CreatedBy,ModifiedBy,CreatedDateTime,ModifiedDateTime) VALUES (@HotelID,@HotelName,@UniqKey,@UserName,@Password,@CreatedBy,@ModifiedBy,@CreatedDateTime,@ModifiedDateTime)"))
                {
                    cmd.Parameters.AddWithValue("@HotelID", HotelID);
                    cmd.Parameters.AddWithValue("@HotelName", HotelName);
                    cmd.Parameters.AddWithValue("@UniqKey", UniqKey);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@CreatedBy", HotelID);
                    cmd.Parameters.AddWithValue("@ModifiedBy", HotelID);
                    cmd.Parameters.AddWithValue("@CreatedDateTime", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Now.Date);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

    }
}

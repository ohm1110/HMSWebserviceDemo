using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Collections;
namespace loginnamespace
{
    /// <summary>
    /// Summary description for Login
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class Login : System.Web.Services.WebService
    {

        public Login()
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
        public DataSet GetLoginAdminDetails(string UserName, string Password)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ToString());
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from HotelRegistration where UserName='" + UserName + "' and Password='" + Password + "' ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;

        }


        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json )]
        public string  GetLoginAdminDetailsJSONFormat(string UserName, string Password)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ToString());
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from HotelRegistration where UserName='" + UserName + "' and Password='" + Password + "' ", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ArrayList root = new ArrayList();
            List<Dictionary<string, object>> table;
            Dictionary<string, object> data;
            foreach (DataTable dt in ds.Tables)
            {
                table = new List<Dictionary<string, object>>();
                foreach (DataRow dr in dt.Rows)
                {
                    data = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        data.Add(col.ColumnName, dr[col]);
                    }
                    table.Add(data);
                }
                root.Add(table);
            }

            return serializer.Serialize(root);

        }
    }
}

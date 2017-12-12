using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using loginnamespace;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Xml;
public partial class _Default : System.Web.UI.Page
{
    loginnamespace.Login login = new loginnamespace.Login();
    DataSet jsonds;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
       
        string strmsg = login.GetLoginAdminDetailsJSONFormat (txtuname.Text, txtpwd.Text);
    
        //DataSet myDataSet = JsonConvert.DeserializeObject<DataSet>(strmsg);

        XmlDocument xd1 = new XmlDocument();
        xd1 = (XmlDocument)JsonConvert.DeserializeXmlNode("{\"root\":" + strmsg + "}", "Detail");
        jsonds = new DataSet();
        jsonds.ReadXml(new XmlNodeReader(xd1));
        if (jsonds.Tables[0].Rows.Count > 0)
        {
            Session["Receptionist"] = txtuname.Text;
            Session["UniqKey"] = jsonds.Tables[0].Rows[0]["UniqKey"].ToString();
            Session["AdminId"] = jsonds.Tables[0].Rows[0]["HotelID"].ToString();

            Response.Redirect("Dashboard.aspx");
            //Response.Write(Session["Receptionist"]);
        }
        else
        {
            ShowMessageBox("Your Username And Password Invalid");
            clear();
        }
    }
    private void ShowMessageBox(string sMessage)
    {
        try
        {
            Page p = (Page)System.Web.HttpContext.Current.Handler;
            p.ClientScript.RegisterStartupScript(p.GetType(), "OnLoad", "<script>alert('" + sMessage + "');</script>");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void clear()
    {
        txtuname.Text = "";
        txtpwd.Text = "";
        //ddlUserType.SelectedIndex = 0;
    }

    protected void btnregister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }
}

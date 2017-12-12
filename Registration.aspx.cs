using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  HotelRegistration;
using System.Data;

public partial class Registration : System.Web.UI.Page
{
    HotelRegistration.HotelRegistration hotelreg = new HotelRegistration.HotelRegistration();
    DataSet jsonds;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        hotelreg.InsertHotelInfo(txtHotelName.Text, "TYTY", txtUserName.Text, txtPassword.Text);
        ShowMessageBox("Insert SuccessFully");
        Response.Redirect("Default.aspx");
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
}
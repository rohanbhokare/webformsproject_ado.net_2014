using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserActivation_aspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["eml"] == null)
            Response.Redirect("~/registration.aspx");
        NIT.RealTime.BLL.UsersData objUser = new NIT.RealTime.BLL.UsersData();
        string EncryEmailId = Request.QueryString["eml"].ToString().Trim();
        string dect = objUser.GetDecryptedData(EncryEmailId, "sunny");
        objUser.EmailId = objUser.GetDecryptedData(EncryEmailId,"sunny");
        if (objUser.ActivateAccount() > 0)
        {
          //  Response.Write("your Account Activated Successfully");
            div1.Visible = true;
        }
        else
        {
            Response.Write("Activation fail");
            div1.Visible = false;
        }
    }
}
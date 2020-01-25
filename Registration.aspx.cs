using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using NIT.RealTime.BLL;
using System.Configuration;
using System.Net;
using System.Net.Mail;

public partial class Registration : System.Web.UI.Page
{
    UsersData objUser;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        objUser = new UsersData();
        objUser.FirstName = txtFirstName.Text.Trim();
        objUser.MiddleName = txtMiddleName.Text.Trim();
        objUser.LastName = txtLastName.Text.Trim();
        objUser.Gender = rdbGender.SelectedItem.Value;
        objUser.DateOfBirth = txtDateOfBirth.Text.Trim();
        objUser.EmailId = txtEmailId.Text.Trim();
        objUser.Password = objUser.GetEncryptedData(txtPassword.Text.Trim(), "sunny");
        objUser.IsActive = false;
        objUser.DateOfRegistration = DateTime.Now;

        if (objUser.UserRegistration() > 0)
        {
            lblStatus.Text = "<b style='color:green'> Registered Successfully!!</b>";

            string message = string.Empty;
            message = "<table width=100% style='width:10px solid green; border-radius:30px;border-shadow:30px 10px blue' >";
            message += "<tr> <td> <img src='http://files.golfpole.webnode.com/200000055-cf2e0d024c/world%20bussiness.png' width='100%' height='150' alt='image'/> <td><tr> ";
            message += "<tr><td> <b> Dear " + txtFirstName.Text.Trim() + ", </b></td></tr>";
            message += "<tr><td> Thankyou for registration plz click following link for activation</td></tr>";
            message += "<tr><td><a href='"+ConfigurationManager.AppSettings["InternetUrl"].ToString()+"UserActivation.aspx?eml="+ objUser.GetEncryptedData(txtEmailId.Text.Trim(),"sunny")+"'>Click Here For Activation</a></td></tr>";
            message += "</table>";
            objUser.SendMail(txtEmailId.Text.Trim(), "Account Activation", message);
            txtFirstName.Text = txtMiddleName.Text = txtLastName.Text = txtDateOfBirth.Text = txtEmailId.Text = txtPassword.Text = txtConfirmPassword.Text = string.Empty;
            rdbGender.SelectedIndex = 0;
        }
        else
        {
            lblStatus.Text = "<b style='color:red'> Registation Failed!!</b>";

        }

    }
}
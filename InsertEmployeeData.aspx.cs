using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using NIT.RealTime.BLL;
public partial class InsertEmployeeData : System.Web.UI.Page
{
    Emp objEmp;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblStatus.Text = string.Empty;
        txtEmpName.Focus();
        if (!Page.IsPostBack)
            BindDeptDLL();
    }

    private void BindDeptDLL()
    {
        objEmp = new Emp();
        DataSet dataSet = objEmp.GetDeptData();

        ddlEmpDept.DataSource = dataSet.Tables[0];
        ddlEmpDept.DataTextField = "DeptName";
        ddlEmpDept.DataValueField = "DeptId";
        ddlEmpDept.DataBind();
        ddlEmpDept.Items.Insert(0, new ListItem("Select","0"));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        objEmp = new Emp();
        objEmp.EmpName = txtEmpName.Text.Trim();
        objEmp.EmpJob = txtEmpJob.Text.Trim();
        objEmp.EmpSalary = decimal.Parse(txtEmpSal.Text.Trim());
        objEmp.DeptId = int.Parse(ddlEmpDept.SelectedItem.Value);

        if (objEmp.InsertEmployeeData() > 0)
        {
            lblStatus.Text = "<b style = 'color:green'> Employee Data Inserted Successfully!!!</b>";
            txtEmpName.Text = txtEmpJob.Text = txtEmpSal.Text = string.Empty;
            ddlEmpDept.SelectedIndex = 0;
        }
        else
        {
            lblStatus.Text = "<b style = 'color:red'> Employee Data Insertion Failed !!!</b>";

        }

    }
}
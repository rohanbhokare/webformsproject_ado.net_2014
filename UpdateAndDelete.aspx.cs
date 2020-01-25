using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using NIT.RealTime.BLL;
public partial class UpdateAndDelete : System.Web.UI.Page
{
    Emp objEmp = new Emp();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblStatus.Text = string.Empty;
        if (!Page.IsPostBack)
        {
            lblStatus.Text = string.Empty;
            BindEmpDdl();
            BindDeptDdl();
        }
    }

    void BindEmpDdl()
    {
        DataSet dataSet = objEmp.GetEmployeeData();
        ddlEmp.DataSource = dataSet.Tables[0];
        ddlEmp.DataTextField = "EmpId";
        ddlEmp.DataValueField = "EmpId";
        ddlEmp.DataBind();
        ddlEmp.Items.Insert(0,new ListItem("select","0"));
    }

    void BindDeptDdl()
    {
         DataSet dataSet = objEmp.GetDeptData();
        ddlDept.DataSource = dataSet.Tables[0];
        ddlDept.DataTextField = "DeptName";
        ddlDept.DataValueField = "DeptId";
        ddlDept.DataBind();
        ddlDept.Items.Insert(0,new ListItem("select","0"));
    }
    protected void ddlEmp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmp.SelectedIndex > 0)
        {
            objEmp = new Emp();
            objEmp.EmpId = int.Parse(ddlEmp.SelectedItem.Value);
            DataSet dataSet = objEmp.GetEmployeeDetails();
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                txtEmpName.Text = dataSet.Tables[0].Rows[0]["EmpName"].ToString();
                txtEmpJob.Text = dataSet.Tables[0].Rows[0]["EmpJob"].ToString();
                txtEmpSal.Text = dataSet.Tables[0].Rows[0]["EmpSalary"].ToString();
                ddlDept.SelectedIndex = ddlDept.Items.IndexOf(ddlDept.Items.FindByValue(dataSet.Tables[0].Rows[0]["DId"].ToString()));
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                lblStatus.Text = "Employee Data is not avalible";
                ControlsToOriginalState();
            }
        }
    }
    void ControlsToOriginalState()
    {
        txtEmpJob.Text = txtEmpName.Text = txtEmpSal.Text = string.Empty;
        ddlEmp.SelectedIndex = 0;
        ddlDept.SelectedIndex = 0;
        btnDelete.Enabled = false;
        btnUpdate.Enabled = false;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objEmp.EmpId = int.Parse(ddlEmp.SelectedItem.Value);
        objEmp.EmpName = txtEmpName.Text.Trim();
        objEmp.EmpJob = txtEmpJob.Text.Trim();
        objEmp.EmpSalary = decimal.Parse(txtEmpSal.Text.Trim());
        objEmp.DeptId = int.Parse(ddlDept.SelectedItem.Value);
        if (objEmp.UpdateEmployeeData() > 0)
        {
            lblStatus.Text = "Employee Data Updated Successfully";
        }
        else
        {
            lblStatus.Text = "Employee Data Updation Failed";
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        objEmp.EmpId = int.Parse(ddlEmp.SelectedItem.Value);
        if (objEmp.DeleteEmployeeData() > 0)
        {
            lblStatus.Text = "Employee Data Deleted Successfully";
            BindEmpDdl();
            ControlsToOriginalState();

        }
        else
        {
            lblStatus.Text = "Employee Data Deletion Failed";
        }
    }
}
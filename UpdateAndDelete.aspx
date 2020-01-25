<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateAndDelete.aspx.cs" Inherits="UpdateAndDelete" Theme="RealTimeTheme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1 class="headingTitle">Update And Delete Employee Data</h1>
        <div class="FirstContent">
            <table>
            <tr>
                <th width="40%">Employee ID</th>
                <th width="2%"> :</th>
                <td><asp:DropDownList ID="ddlEmp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEmp_SelectedIndexChanged"/></td>
            </tr>
            <tr>
                <th width="40%">Employee Name</th>
                <th width="2%"> :</th>
                <td><asp:TextBox ID="txtEmpName" runat="server" placeholder="Enter Employee Name"/>
                  
                </td>
            </tr>
            <tr>
                <th>Employee Job</th>
                <th>:</th>
                <td><asp:TextBox ID="txtEmpJob" runat="server" placeholder="Enter Employee Job" /></td>
            </tr>
            <tr>
                <th>Employee Salary</th>
                <th>:</th>
                <td><asp:TextBox ID="txtEmpSal" runat="server" placeholder="Enter Employee salary" /></td>
            </tr>
            <tr>
                <th>Departmant Name</th>
                <th>:</th>
                <td><asp:DropDownList ID="ddlDept" runat="server" placeholder="select" /></td>
            </tr>
            <tr>
                <th></th>
                <th></th>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" text="Update" OnClick="btnUpdate_Click" Enabled="false"/>
      &nbsp              <asp:Button ID="btnDelete" runat="server" text="Delete" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you Sure,You Want to Delete?')" Enabled="false"/>
           &nbsp         <input type="reset" value="Reset" />
                </td>
            </tr>
            <tr>
                <th colspan="3" style="text-align:center">
                    <asp:Label ID="lblStatus" runat="server" />
                </th>
            </tr>

            </table>
        </div>
    </form>
</body>
</html>

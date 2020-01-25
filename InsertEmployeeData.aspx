<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertEmployeeData.aspx.cs" Inherits="InsertEmployeeData" Theme="RealTimeTheme"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <link href="Style/PublicStyleSheet.css" rel="stylesheet" type="text/css" />
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1 class="headingTitle">Insert Employee Details</h1>
        <div >
        <table >
            <tr>
                <th width="40%">Employee Name</th>
                <th width="2%"> :</th>
                <td><asp:TextBox ID="txtEmpName" runat="server" placeholder="Enter Employee Name"/>
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtEmpName" ErrorMessage="Please Enter EmpName" Display="None" />
                    <cc1:ValidatorCalloutExtender HighlightCssClass="highlightError" ID="vce1" runat="server" TargetControlID="rfv1"></cc1:ValidatorCalloutExtender>
                </td>
                  
            </tr>
            <tr>
                <th>Employee Job</th>
                <th>:</th>
                <td><asp:TextBox ID="txtEmpJob" runat="server" placeholder="Enter Employee Job" />
                     <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtEmpJob" ErrorMessage="Please Enter EmpJob" Display="None" />
                    <cc1:ValidatorCalloutExtender HighlightCssClass="highlightError" ID="vce2" runat="server" TargetControlID="rfv2"></cc1:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <th>Employee Salary
                     

                </th>
                <th>:</th>
                <td><asp:TextBox ID="txtEmpSal" runat="server" placeholder="Enter Employee salary" SkinID=""/>
                     <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtEmpSal" ErrorMessage="Please Enter Emp Salary" Display="None" />
                    <cc1:ValidatorCalloutExtender HighlightCssClass="highlightError" ID="vce3" runat="server" TargetControlID="rfv3"></cc1:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <th>Departmant Name</th>
                <th>:</th>
                <td><asp:DropDownList ID="ddlEmpDept" runat="server" placeholder="select" />
                    <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="ddlEmpDept" InitialValue="0" ErrorMessage="Plz Select" Display="None" />
                    <cc1:ValidatorCalloutExtender HighlightCssClass="highlightError" ID="vce4" runat="server" TargetControlID="rfv4"></cc1:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <th></th>
                <th></th>
                <td><asp:Button ID="btnSave" runat="server" text="Save" OnClick="btnSave_Click"/></td>
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

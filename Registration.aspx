<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="Registration.aspx.cs" Inherits="Registration" Theme="RealTimeTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.1.4.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.9.2.js" type="text/javascript"></script>
    <link href="JQueryThemes/black-tie/jquery-ui.css" rel="stylesheet" />
    <link href="JQueryThemes/black-tie/theme.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtDateOfBirth").datepicker({
                showOn: "button",
                buttonText:'Calendar',
                buttonImage: 'Images/cal.png',
                buttonImageOnly:true,
                maxDate: 0,
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:0",
                dateFormat: "dd-M-yy"
            });
            var email = $("#<%=txtEmailId.ClientID%>");
            var emailStatus = $("#<%=lblEmailStatus.ClientID%>");
            email.blur(function(){
                if(email!=""){
                    $.ajax({
                        contentType:"text/html; charset=utg8",
                        data:"email="+email.val(),
                        url:"CheckEmailRegistered.aspx",
                        dataType:"html",
                        success:function(data){
                            email.html(data);
    });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h1>Registration</h1>
        <table width="100%">
            <tr>
                <td width="20%">First Name</td> 
                <td width="2%">:</td>
                <td> 
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please enter first name" Display="None" />
                    <cc1:ValidatorCalloutExtender ID="vce1" runat="server" TargetControlID="rfv1" WarningIconImageUrl="~/Images/alert.gif"></cc1:ValidatorCalloutExtender>
                </td>
               
            </tr>
            <tr>
                <td>Middle Name</td>
                <td>:</td>
                <td> <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td>Last Name
                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtLastName" ErrorMessage="Please enter last name" Display="None" />
                    <cc1:ValidatorCalloutExtender ID="vce2" runat="server" TargetControlID="rfv2" WarningIconImageUrl="~/Images/alert.gif"></cc1:ValidatorCalloutExtender>
                </td>
                <td>:</td>
                <td> <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>:</td>
                <td><asp:RadioButtonList ID="rdbGender" runat="server" RepeatDirection="Horizontal" >
                    <asp:ListItem Text="Male" Selected="True" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    </asp:RadioButtonList> </td>
            </tr>
            <tr>
                <td>Date of Birth</td>
                <td>:</td>
                <td> <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txtDateOfBirth" ErrorMessage="Please enter date of birth" Display="None" />
                    <cc1:ValidatorCalloutExtender ID="vce3" runat="server" TargetControlID="rfv3" WarningIconImageUrl="~/Images/alert.gif"></cc1:ValidatorCalloutExtender>
                </td>
            </tr>

            <tr>
                <td>Email-Id</td>
                <td>:</td>
                <td> <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox> <asp:Label ID="lblEmailStatus" runat="server"></asp:Label>
                     <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="txtEmailId" ErrorMessage="Email-id is not valid" Display="None" />
                    <cc1:ValidatorCalloutExtender ID="vce5" runat="server" TargetControlID="rfv4" WarningIconImageUrl="~/Images/alert.gif"></cc1:ValidatorCalloutExtender>
                <asp:RegularExpressionValidator ID="rev1" runat="server" ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Email-id is not valid" Display="None" />
                <cc1:ValidatorCalloutExtender ID="vce4" runat="server" TargetControlID="rev1" WarningIconImageUrl="~/Images/alert.gif"></cc1:ValidatorCalloutExtender>   
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>:</td>
               :</td>
                <td> <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter password" Display="None" />
                    <cc1:ValidatorCalloutExtender ID="vce6" runat="server" TargetControlID="rfv5" WarningIconImageUrl="~/Images/alert.gif"></cc1:ValidatorCalloutExtender>
                <asp:RegularExpressionValidator ID="rev2" runat="server" ControlToValidate="txtPassword" ValidationExpression="[a-zA-Z0-9'@&amp;#.\s]{6,10}$" ErrorMessage="min 6 characters max 16" Display="None" />
                <cc1:ValidatorCalloutExtender ID="vce7" runat="server" TargetControlID="rev2" WarningIconImageUrl="~/Images/alert.gif"></cc1:ValidatorCalloutExtender>   
                   
                </td>
            </tr>
            <tr>
                <td>Confirm Password<td>:</td>
                <td> <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="cv1" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Passwor and Comfirm password are not same" Display="None" />
                <cc1:ValidatorCalloutExtender ID="vce8" runat="server" TargetControlID="cv1" WarningIconImageUrl="~/Images/alert.gif"    />
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td><asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click"></asp:Button></td>
            </tr>
     

        </table>
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>

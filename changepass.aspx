<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepass.aspx.cs" Inherits="Salon_Management_System.changepass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="chagePassForm" runat="server">
       
 <div>
     old password:
     <asp:TextBox ID="txtOldPass" type="password" runat="server" required></asp:TextBox>
     <br />
     New password :<asp:TextBox ID="txtpass" type="password" runat="server" required></asp:TextBox>
 </div>
        <div>
            confirm password : <asp:TextBox ID="txtnewpass" type="password" runat="server" required></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnchangepass" runat="server"  Text="Change password" OnClick="btnchangepass_Click" />
            <br />
            <br />
        </div>
 
    </form>
</body>
</html>

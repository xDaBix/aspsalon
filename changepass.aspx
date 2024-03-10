<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepass.aspx.cs" Inherits="Salon.changepass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
     email:<asp:TextBox ID="txtemail" type="email" runat="server" required></asp:TextBox>
 </div>
 <div>
     password<asp:TextBox ID="txtpass" type="password" runat="server" required></asp:TextBox>
 </div>
        <div>
            new password:<asp:TextBox ID="txtnewpass" type="password" runat="server" required></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnchangepass" runat="server"  Text="Change password" OnClick="btnchangepass_Click" />
        </div>
 
    </form>
</body>
</html>

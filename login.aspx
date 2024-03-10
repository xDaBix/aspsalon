<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Salon.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>
        <h2>Login Details</h2>
    </div>
    <form id="form1" runat="server">
        <div>
            email:<asp:TextBox ID="txtemail" type="email" runat="server" required></asp:TextBox>
        </div>
        <div>
            password<asp:TextBox ID="txtpass" type="password" runat="server" required></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnlogin" Text="login" runat="server" OnClick="btnlogin_Click" />
        </div>
    </form>
</body>
</html>

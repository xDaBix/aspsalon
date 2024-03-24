<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Salon_Management_System.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
    </script>
    <form id="loginForm" runat="server">
        <div>
            <asp:Label ID="lblUID" runat="server"></asp:Label>
            <br />
            <br />
            email:<asp:TextBox ID="txtemail" type="email" runat="server" required></asp:TextBox>
        </div>
        <div>
            password<asp:TextBox ID="txtpass" type="password" runat="server" required></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnlogin" Text="login" runat="server" OnClick="btnlogin_Click" />
            <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="forgetPassword.aspx">Forget Password?</asp:HyperLink>
            &nbsp;&nbsp;&nbsp; Haven&#39;t registered yet?
            <asp:HyperLink ID="hlRegister" runat="server" NavigateUrl="~/Default.aspx">Create Account.</asp:HyperLink>
            <br />
        </div>
    </form>
</body>
</html>

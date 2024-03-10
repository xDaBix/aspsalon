<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="Salon.welcome" %>
<%if (Session["uid"] == null)
    {
        Response.Redirect("Default.aspx");
    } %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="logout" Text="logout" runat="server" OnClick="logout_Click" />
        </div>
        <div>
    <asp:Button ID="changepassowrd" Text="change password" runat="server" OnClick="changepassowrd_Click" />
</div>
    </form>
</body>
</html>

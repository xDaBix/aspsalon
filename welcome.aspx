<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="Salon_Management_System.welcome" %>

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

    <form id="welcomeForm" runat="server">
        <p>
            <br />
            Wel-come
            <asp:Label ID="lblUID" runat="server"></asp:Label>
        </p>
        <div>
            <asp:Button ID="logout" Text="logout" runat="server" OnClick="logout_Click" />
        </div>
        <div>
    <asp:Button ID="changepassowrd" Text="change password" runat="server" OnClick="changepassowrd_Click" />
</div>
    </form>
</body>
</html>

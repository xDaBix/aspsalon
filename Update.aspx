<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="CAT.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            <br />
            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox><br />
             <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList><br />
            <asp:Button ID="BtnUpdatep" runat="server" Text="Updatep" OnClick="BtnUpdatep_Click" />
        </div>
    </form>
</body>
</html>

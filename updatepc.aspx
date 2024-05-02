<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updatepc.aspx.cs" Inherits="CAT.updatepc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox><br />

            <asp:Button ID="btnupdatepc" runat="server" Text="PC" OnClick="btnupdatepc_Click" />
        </div>
    </form>
</body>
</html>

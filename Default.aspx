﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CAT.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Btnpc" Text="PC" runat="server" OnClick="Btnpc_Click" />
            <asp:Repeater ID="ProductRepeater" runat="server">
                <HeaderTemplate>
                    <table border="1" cellspacing="0">
                        <tr>
                            <th>Product Name</th>
                            <th>Category ID</th>
                            <th>Action</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ProductName") %></td>
                        <td><%# Eval("CategoryID") %></td>
                        <td><a href='<%# "Update.aspx?id=" + Eval("ProductID") %>'>Update</a></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>

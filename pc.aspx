<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pc.aspx.cs" Inherits="CAT.pc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="ProductRepeater" runat="server">
                <HeaderTemplate>
                    <table border="1" cellspacing="0">
                        <tr>
                            <th>Category ID</th>
                            <th>Category Name</th>
                            <th>types</th>
                            <th>Action</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("CategoryID") %></td>
                        <td><%# Eval("CategoryName") %></td>
                        <td><%# Eval("types") %></td>
                        <td><a href='<%# "updatepc.aspx?id=" + Eval("CategoryID") %>'>Update</a></td>
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

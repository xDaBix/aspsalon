<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Salon.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registration</h2>
        </div>
        <div>
           Full Name:<asp:TextBox ID="txtname" runat="server" required ></asp:TextBox><br /><br />
        </div>
         <div>
        Contact No:<asp:TextBox ID="txtcontact" runat="server" required></asp:TextBox><br /><br />
        </div>
         <div>
    Age:<asp:TextBox ID="txtage" runat="server" type="number" required></asp:TextBox><br /><br />
        </div>
             <div>
Gender:<asp:RadioButton Text="male" ID="rbmale" runat="server" ></asp:RadioButton>
       <asp:RadioButton Text="female" ID="rbfemale" runat="server" ></asp:RadioButton><br /><br />
    </div>

         <div>
    Email:<asp:TextBox ID="txtemail" runat="server" type="email" required></asp:TextBox><br /><br />
 </div>
        <div>
        password:<asp:TextBox ID="txtpass" runat="server" type="password" required></asp:TextBox><br /><br />
        </div>
         <div>
        Confirm Password:<asp:TextBox ID="txtconpass" runat="server" type="password" required></asp:TextBox><br /><br />
 </div>
       <asp:Button ID="btnclick" runat="server" Text="register" OnClick="btnclick_Click" />
        <div>
            <asp:Label ID="txterror" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>

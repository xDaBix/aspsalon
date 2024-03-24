<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgetPassword.aspx.cs" Inherits="Salon_Management_System.forgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="forgetPasswordForm" runat="server">
        <div>
            
            <asp:Label ID="lblUID" runat="server"></asp:Label>
            <br />
            <br />
            email:<asp:TextBox ID="txtemail" type="email" runat="server" required></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblReg" runat="server" Visible="False"> Seems you aren&#39;t registered!</asp:Label>
                <asp:HyperLink ID="hlReg" runat="server" Visible="False" NavigateUrl="Default.aspx">Register Now.</asp:HyperLink>
                </div>
        <div>
            <asp:Button ID="btnSendOtp" Text="Send OTP" runat="server" OnClick="btnSendOtp_Click"  />
            <br />
            <br />
            <asp:Label ID="lblOTP" runat="server" Text="Enter OTP: "></asp:Label>
            <asp:TextBox ID="txtOTP" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnOTP" runat="server" OnClick="btnOTP_Click" Text="Submit" />
            <br />
        </div>
        
    </form>
</body>
</html>

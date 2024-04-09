<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddService.aspx.cs" Inherits="SalonProject.admin.AddService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <style>
    .form-container {
        max-width: 500px;
        margin: auto;
        padding: 20px;
        border: 1px solid #ccc;
        border-radius: 5px;
        background-color: #f9f9f9;
    }

    .form-container h2 {
        margin-top: 0;
    }

    .form-group {
        margin-bottom: 15px;
    }

    .form-group label {
        display: block;
        font-weight: bold;
    }

    .form-group input[type="text"],
    .form-group input[type="number"],
    .form-group select,
    .form-group textarea {
        width: 100%;
        padding: 8px;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }

    .form-group select {
        height: 38px; 
    }

    .form-group textarea {
        resize: vertical;
    }

    .form-group label.error {
        color: red;
    }

    .form-group input[type="submit"] {
        background-color: #4CAF50;
        color: white;
        padding: 10px 20px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

    .form-group input[type="submit"]:hover {
        background-color: #45a049;
    }

    .form-group label.required::after {
        content: "*";
        color: red;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
      
        <div>
            <h2>Add Service</h2>
            <div class="form-group">
                <label for="ddlServiceType" class="required">Select Type of Service:</label>
                <asp:DropDownList ID="ddlServiceType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlServiceType_SelectedIndexChanged" required="true">
                    <asp:ListItem Value="" Text="Select Type" Disabled="true" Selected="true"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="ddlServiceCategory" class="required">Select Service Category:</label>
                <asp:DropDownList ID="ddlServiceCategory" runat="server" required="true">
                    <asp:ListItem Value="" Text="Select Category" Disabled="true" Selected="true"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtServiceName" class="required">Service Name:</label>
                <asp:TextBox ID="txtServiceName" runat="server" required="true"></asp:TextBox>
                <div>
                    <asp:Label ID="errname" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="txtDescription" class="required">Description:</label>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" required="true" Rows="2"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtPrice" class="required">Price:</label>
                <asp:TextBox ID="txtPrice" runat="server" type="number" required="true" step="0.01"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnAddService" runat="server" Text="Add Service" OnClick="btnAddService_Click" />
                <div>
                    <asp:Label ID="txterror" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>

    </form>
</body>
</html>

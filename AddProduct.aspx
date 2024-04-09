<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="SalonProject.admin.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    .form-container {
        /* Add styles for the container */
        margin: 20px;
        padding: 20px;
        border: 1px solid #ccc;
        border-radius: 5px;
        background-color: #f9f9f9;
    }

    .form-group {
        /* Add styles for each form group */
        margin-bottom: 15px;
    }

    label {
        /* Add styles for labels */
        font-weight: bold;
    }

    input[type="text"],
    input[type="number"],
    textarea,
    select {
        /* Add styles for textboxes, number inputs, textareas, and dropdowns */
        width: 100%;
        padding: 8px;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }

    .btnSubmit {
        /* Add styles for the submit button */
        background-color: #4CAF50;
        color: white;
        padding: 10px 20px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

    .btnSubmit:hover {
        /* Add styles for hover state of the submit button */
        background-color: #45a049;
    }

    .error-message {
        /* Add styles for error messages */
        color: red;
    }
    .form-container h2 {
        margin-top: 0;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
         <h2>Add Product</h2>

                 <div class="form-container">
            <div class="form-group">
                <label for="ddlProductType" class="required">Select Type of Product:</label>
                <asp:DropDownList ID="ddlProductType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlProductType_SelectedIndexChanged" required="true">
                    <asp:ListItem Value="" Text="Select Type" Disabled="true" Selected="true"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="ddlCategory">Product Category:</label>
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtName">Product Name:</label>
                <asp:TextBox ID="txtPName" runat="server" CssClass="form-control"></asp:TextBox>
                <div>
                    <asp:Label ID="errname" runat="server" CssClass="error-message"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <label for="fileImage">Product Image:</label>
                <asp:FileUpload ID="filePImage" runat="server" CssClass="form-control"></asp:FileUpload>
            </div>
            <div class="form-group">
                <label for="txtDescription">Product Description:</label>
                <asp:TextBox ID="txtPDescription" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtPrice">Product Price:</label>
                <asp:TextBox ID="txtPPrice" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtStock">Total Stock:</label>
                <asp:TextBox ID="txtPStock" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnSubmit" runat="server" Text="Add Product" OnClick="btnSubmit_Click" CssClass="btnSubmit" />
                <div>
                    <asp:Label ID="txterror" runat="server" CssClass="error-message"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

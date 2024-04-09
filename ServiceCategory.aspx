<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceCategory.aspx.cs" Inherits="SalonProject.admin.ServiceCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Insert Service Category</title>
    <style>

        h2{
            text-align:center;
        }
     
        .form-container {
            margin-top:7%;
            width: 50%;
            margin-left:24%;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
        }
        .form-group input[type=text], .form-group select {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .btnadd {
            background-color: #331414;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            margin-left:45%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <div class="form-container">
            <h2>Add Service Category</h2><br /><br />
           
            <div class="form-group">
                <label for="txtCategoryName">Enter Service Categor:</label>
                <asp:TextBox ID="txtCategoryName" runat="server"    pattern="^[a-zA-Z\s]+$" required="true" ></asp:TextBox>
                 <div>
                      <asp:Label ID="errname" runat="server" ForeColor="Red"></asp:Label>
                    </div>
            </div><br />
            <div class="form-group">
                <label for="ddlCategoryType">Select Service Type:</label>
                <asp:DropDownList ID="ddlCategoryType" runat="server" required="true">
                     <asp:ListItem Value="" Text="Select Type" Disabled="true" Selected="true"></asp:ListItem>
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                 
                </asp:DropDownList>
            </div><br /><br />

           <asp:Button ID="add" class="btnadd" Text="Add" runat="server" OnClick="AddClick" />
           <div>
                        <asp:Label ID="txterror" runat="server" ForeColor="Red"></asp:Label>
                    </div>
        </div>
    </form>
</body>
</html>

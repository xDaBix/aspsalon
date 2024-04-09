<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStaffSchedule.aspx.cs" Inherits="SalonProject.admin.AddStaffSchedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
        }

        .container {
            max-width: 400px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            color: #333;
            text-align: center;
            margin-bottom: 20px;
        }

        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }

        input[type="text"],
        input[type="date"],
        select {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 3px;
            box-sizing: border-box;
        }

        select {
            cursor: pointer;
        }

        input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            font-size: 16px;
        }

        .message {
            color: #4CAF50;
            font-weight: bold;
            text-align: center;
            margin-top: 15px;
        }

        .error-message {
            color: #f00;
            font-weight: bold;
            text-align: center;
            margin-top: 15px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
          <div class="container">
            <h2>Assign Stylist Availability</h2>
            <div>
                <label for="ddlStylist">Select Stylist:</label>
                <asp:DropDownList ID="ddlStylist" runat="server" CssClass="form-control" required="true" />
                     <asp:ListItem Value="" Text="Select Stylist" Disabled="true" Selected="true"></asp:ListItem>
            </div>
            <div>
                <label for="txtDate">Select Date:</label>
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control" required="true" />
            </div>
            <div>
                <label for="ddlTime">Select Time:</label>
                <asp:DropDownList ID="ddlTime" runat="server" CssClass="form-control" required="true" >
                     <asp:ListItem Value="" Text="Select Time" Disabled="true" Selected="true"></asp:ListItem>

                    <asp:ListItem Text="09:00 AM" Value="09:00:00" />
                    <asp:ListItem Text="10:00 AM" Value="10:00:00" />
                    <asp:ListItem Text="11:00 AM" Value="11:00:00" />
                    <asp:ListItem Text="12:00 PM" Value="12:00:00" />
                    <asp:ListItem Text="01:00 PM" Value="13:00:00" />
                    <asp:ListItem Text="02:00 PM" Value="14:00:00" />
                    <asp:ListItem Text="03:00 PM" Value="15:00:00" />
                    <asp:ListItem Text="04:00 PM" Value="16:00:00" />
                    <asp:ListItem Text="05:00 PM" Value="17:00:00" />
                    <asp:ListItem Text="06:00 PM" Value="19:00:00" />
                    <asp:ListItem Text="07:00 PM" Value="20:00:00" />
                </asp:DropDownList>
            </div>
            <div>
                <asp:Button ID="btnAssignAvailability" runat="server" Text="Assign Availability" OnClick="btnAssignAvailability_Click" CssClass="btn btn-primary" />
            </div>
            <div>
                 <asp:Label ID="txterror" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>

    </form>
</body>
</html>

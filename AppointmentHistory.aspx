<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentHistory.aspx.cs" Inherits="SalonProject.AppointmentHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
      
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th{
            border: 1px solid black;
            text-align: center;
            padding: 10px;
        }

        td{
             border: 1px dotted grey;
             text-align: center;
            padding: 10px;
        }

        tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        
        #form1 {
            margin: 0 auto;
            width: 100%;
            padding: 30px px 30px;
        }

        
        h1 {
            text-align: center;
            margin-bottom: 20px;
        }

        
        a {
            text-decoration: none;
            color: #333;
        }

        a:hover {
            color:#000000;
        }
         </style>

</head>
<body>
       <%  Server.Execute("customernav.aspx");%>
    <form id="form1" runat="server">
       
        <div>
            <h1>Service Appointment Details</h1>

            <table>
                <tr>
                    <th>Name</th>
                    <th>Contact No</th>
                    <th>Service Type</th>
                    <th>Service Category</th>
                    <th>Service</th>
                    <th>Price</th>
                    <th>Expert Name</th>
                    <th>Date</th>
                    <th>Time</th>
                    <th>Status</th>

                    
                </tr>
                <asp:Repeater runat="server" ID="ViewStaff">
                    <ItemTemplate>
                        <tr>
                          
                           <td><%# Eval("Name") %></td>
                            <td><%# Eval("Contact") %></td>
                            <td><%# Eval("Gender") %></td>
                            <td><%# Eval("ServiceCategory") %></td>
                            <td><%# Eval("Service") %></td>
                            <td><%# Eval("Price") %></td>
                            <td><%# Eval("Expert") %></td>
                            <td><%# Eval("Date") %></td>
                            <td><%# Eval("Time") %></td>
                            <td><%# Eval("Status") %></td>
                            
                            

                            </tr>
                    </ItemTemplate>

                </asp:Repeater>
            </table>
           
        </div>
      

    </form>
       <%  Server.Execute("footer.aspx");%>

</body>
</html>

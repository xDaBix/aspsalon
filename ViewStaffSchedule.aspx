<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStaffSchedule.aspx.cs" Inherits="SalonProject.admin.ViewStaffSchedule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            border: 1px solid #dddddd;
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
     <%  Server.Execute("adminnav.aspx");%>
    <form id="form1" runat="server">
       <br />
             <a href="AddStaffSchedule.aspx" style="background-color:#512c09; font-style:oblique; border:solid 1px black; color:wheat; font-size:20px">Add Staff Schedule</a>

          <div>
            <h1>Staff Schedule</h1>

            <table>
                <tr>
                    <th>Staff Name</th>
                    <th>Date</th>
                    <th>Time</th>
                       <th>Action</th>
                </tr>
                <asp:Repeater runat="server" ID="ViewStaff">
                    <ItemTemplate>
                        <tr>
                          
                            <td><%# Eval("Sname") %></td>
                            <td><%# Eval("Date") %></td>
                            <td><%# Eval("Time") %></td>

                            <td><a href="#">Edit</a>&nbsp;&nbsp;|<a href="ViewStaffSchedule.aspx?id=<%# Eval("ScheduleId") %>">Delete</a></td>
                        </tr>
                    </ItemTemplate>

                </asp:Repeater>
            </table>
        </div>
      

    </form>
</body>
</html>

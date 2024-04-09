using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SalonProject.admin
{
    public partial class AddStaffSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
              
                LoadStylists();
                ClearFields();
            }

            DateTime maxDate = DateTime.Now.AddDays(7);
            txtDate.Attributes["max"] = maxDate.ToString("yyyy-MM-dd");
            txtDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void btnAssignAvailability_Click(object sender, EventArgs e)
        {

         
            int stylistID = Convert.ToInt32(ddlStylist.SelectedValue);
            string stylistName = ddlStylist.SelectedItem.Text;
            String Status = "Pending";
          
            DateTime date = Convert.ToDateTime(txtDate.Text);
            TimeSpan time = TimeSpan.Parse(ddlTime.SelectedValue);



            if (IsRecordAlreadyExists(stylistID, date, time))
            {
                txterror.Text = "This availability record already exists.";
             
                return;
            }



            string connectionString = "Data Source=NUPUR;Initial Catalog=salon;Integrated Security=True";

            string query = "INSERT INTO StylistSchedule (StylistID, Date, Time, Status) VALUES (@StylistID, @Date, @Time, @status)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StylistID", stylistID);
                        command.Parameters.AddWithValue("@status",Status );
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@Time", time);

                        connection.Open();
                        command.ExecuteNonQuery();

                        HttpContext.Current.Response.Write("<script>alert('Slot Add Successfullyy!!!!!');</script>");


                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                txterror.Text = "Error: " + ex.Message;
            }

        }

        private void LoadStylists()
        {
            string connectionString = "Data Source=NUPUR;Initial Catalog=salon;Integrated Security=True";

            string query = "SELECT id, name FROM Staff where designation='Stylist'";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        ddlStylist.DataSource = reader;
                        ddlStylist.DataTextField = "name";
                        ddlStylist.DataValueField = "id";
                        ddlStylist.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private bool IsRecordAlreadyExists(int stylistID, DateTime date, TimeSpan time)
        {
            string connectionString1 = "Data Source=NUPUR;Initial Catalog=salon;Integrated Security=True";
            string query1 = "SELECT COUNT(*) FROM StylistSchedule WHERE StylistID = @StylistID AND Date = @Date AND Time = @Time";

            using (SqlConnection connection = new SqlConnection(connectionString1))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@StylistID", stylistID);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Time", time);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void ClearFields()
        {
            txtDate.Text = string.Empty;
            ddlTime.SelectedIndex = 0;
            txterror.Text = "";
        }
    }
}
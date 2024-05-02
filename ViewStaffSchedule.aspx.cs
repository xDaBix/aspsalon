using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SalonProject.admin
{
    public partial class ViewStaffSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {

                Response.Redirect("~/admin/login.aspx");
            }
            if (!IsPostBack)
            {
                LoadData();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int id;
                if (int.TryParse(Request.QueryString["id"], out id))
                {
                    DeleteSlot(id);
                }
            }

        }


        protected void DeleteSlot(int id)
        {
            string connectionString = "Data Source=NUPUR;Initial Catalog=salon;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM StylistSchedule WHERE ScheduleId=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();


                string script = "alert('Record Deleted Successfully!!!');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

                con.Close();
            }
            Response.Redirect("~/admin/ViewStaffSchedule.aspx");

        }

        protected void LoadData()
        {
            string connectionString = "Data Source=NUPUR;Initial Catalog=salon;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Staff.name AS SName, StylistSchedule.Date, StylistSchedule.* FROM StylistSchedule INNER JOIN Staff ON StylistSchedule.StylistID = Staff.id", con);
                DataTable dt = new DataTable();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                {
                    dataAdapter.Fill(dt);
                }

                ViewStaff.DataSource = dt;
                ViewStaff.DataBind();
            }
        }

    }
}
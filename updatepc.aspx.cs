using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace CAT
{
    public partial class updatepc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int categoryId = Convert.ToInt32(Request.QueryString["id"]);
                    LoadCat(categoryId);
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btnupdatepc_Click(object sender, EventArgs e)
        {
            int categoryId = Convert.ToInt32(Request.QueryString["id"]);
            string categoryName = txtProductName.Text;
            string connectionString = "Data Source=DESKTOP-EVLGQHH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";

            string updateQuery = "UPDATE pc SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryName", categoryName);
                        command.Parameters.AddWithValue("@CategoryID", categoryId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Category updated successfully.";
                        }
                        else
                        {
                            lblMessage.Text = "Category not found or update failed.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        private void LoadCat(int categoryId)
        {
            string connectionString = "Data Source=DESKTOP-EVLGQHH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string query = "SELECT CategoryName FROM pc WHERE CategoryID = @CategoryID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryId);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            txtProductName.Text = reader["CategoryName"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}

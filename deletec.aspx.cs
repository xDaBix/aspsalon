using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace CAT
{
    public partial class DeleteCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int categoryId = Convert.ToInt32(Request.QueryString["id"]);

                    // Check if there are any products linked to the category
                    if (!CategoryHasProducts(categoryId))
                    {
                        if (DeleteCategoryById(categoryId))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Category deleted successfully.'); window.location = 'pc.aspx';", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Failed to delete category.'); window.location = 'pc.aspx';", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Cannot delete category. There are products linked to it.'); window.location = 'pc.aspx';", true);
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        private bool CategoryHasProducts(int categoryId)
        {
            string connectionString = "Data Source=DESKTOP-EVLGQHH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM Products WHERE CategoryID = @CategoryID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryId);
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return true;
            }
        }

        private bool DeleteCategoryById(int categoryId)
        {
            string connectionString = "Data Source=DESKTOP-EVLGQHH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string deleteQuery = "DELETE FROM pc WHERE CategoryID = @CategoryID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryId);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

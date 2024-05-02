using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CAT
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int productId = Convert.ToInt32(Request.QueryString["id"]);
                    LoadProductDetails(productId);
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }

                BindCategories();
            }
        }

        private void BindCategories()
        {
            string connectionString = "Data Source=DESKTOP-EVLGQHH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string query = "SELECT CategoryID, CategoryName FROM pc";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        ddlCategory.DataSource = reader;
                        ddlCategory.DataTextField = "CategoryName";
                        ddlCategory.DataValueField = "CategoryID";
                        ddlCategory.DataBind();
                        ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", "0")); 
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void LoadProductDetails(int productId)
        {
            string connectionString = "Data Source=DESKTOP-EVLGQHH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string query = "SELECT ProductName, CategoryID FROM p WHERE ProductID = @ProductID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", productId);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            txtProductName.Text = reader["ProductName"].ToString();
                            ddlCategory.SelectedValue = reader["CategoryID"].ToString();
                        }
                        else
                        {
                            lblMessage.Text = "Product not found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void BtnUpdatep_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(Request.QueryString["id"]);
            string productName = txtProductName.Text;
            int categoryId = Convert.ToInt32(ddlCategory.SelectedValue); 

           

            string connectionString = "Data Source=DESKTOP-EVLGQHH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string updateQuery = "UPDATE p SET ProductName = @ProductName, CategoryID = @CategoryID WHERE ProductID = @ProductID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", productName);
                        command.Parameters.AddWithValue("@CategoryID", categoryId);
                        command.Parameters.AddWithValue("@ProductID", productId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Product updated successfully.";
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            lblMessage.Text = "Product not found or update failed.";
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
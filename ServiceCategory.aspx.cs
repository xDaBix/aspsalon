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
    public partial class ServiceCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                ClearFields();
            }
        }

        protected void AddClick(object sender, EventArgs e)
        {
            string connectionString = "Data Source=NUPUR;Initial Catalog=salon;Integrated Security=True";


            String categoryName = "";
            bool value = true;
            if (!string.IsNullOrEmpty(txtCategoryName.Text.Trim()))
            {

                string inputCategoryName = txtCategoryName.Text.Trim().ToLower();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string qry = "SELECT * FROM ServiceCategory WHERE LOWER(CategoryName) = @name and CType=@type" ;
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        cmd.Parameters.AddWithValue("@name", txtCategoryName.Text.Trim());
                        cmd.Parameters.AddWithValue("@type", ddlCategoryType.SelectedValue);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {

                                value = false;
                                errname.Text = "Category is already Added";
                                
                            }
                            else
                            {

                                categoryName = txtCategoryName.Text.Trim();
                               
                            }
                        }
                    }
                }

            }
            else
            {
                value = false;
                errname.Text = "enter valid Category";
            }

         
          



            if (value == true)
            {

                string query = "INSERT INTO ServiceCategory (CategoryName, CType) VALUES (@CategoryName, @CategoryType)";







                try
                {

                    string categoryType = ddlCategoryType.SelectedValue;


                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {


                            command.Parameters.AddWithValue("@CategoryName", categoryName);
                            command.Parameters.AddWithValue("@CategoryType", categoryType);

                            connection.Open();
                            command.ExecuteNonQuery();
                            HttpContext.Current.Response.Write("<script>alert('Category Add Successfullyy!!!!!');</script>");
                        }
                    }
                    ClearFields();

                }
                catch (Exception ex)
                {
                    txterror.Text = "Error: " + ex.Message;
                }

            }
           

        }

        private void ClearFields()
        {
           
            txtCategoryName.Text = "";
            ddlCategoryType.SelectedIndex = 0;
            errname.Text = "";
            txterror.Text = "";
        }

    }
}
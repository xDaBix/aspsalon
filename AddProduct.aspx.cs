using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace SalonProject.admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearFields();
            }

        }

        protected void ddlProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string productType = ddlProductType.SelectedValue;
            PopulateServiceCategories(productType);
        }

        private void PopulateServiceCategories(string productType)
        {
            string connectionString = "Data Source=NUPUR;Initial Catalog=salon;Integrated Security=True";

            string query = "SELECT CategoryName FROM ProductCategory WHERE CType = @Type";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type", productType);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ddlCategory.Items.Clear();
                        while (reader.Read())
                        {
                            string categoryName = reader["CategoryName"].ToString();
                            ddlCategory.Items.Add(new ListItem(categoryName, categoryName));
                        }
                    }
                }
            }


        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=NUPUR;Initial Catalog=salon;Integrated Security=True";
            string productType = ddlProductType.SelectedValue;
            string CategoryName = ddlCategory.SelectedItem.Text;

            string name = "";
            string description = txtPDescription.Text.Trim();
            decimal price = Convert.ToDecimal(txtPPrice.Text.Trim());
            int stock = Convert.ToInt32(txtPStock.Text);
            string imagePath = UploadImage();



            int categoryId;

            string query1 = "SELECT CategoryID FROM ProductCategory WHERE CategoryName = @CategoryName and CType=@type";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", CategoryName);
                    command.Parameters.AddWithValue("@type", productType);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        categoryId = Convert.ToInt32(result);
                    }
                    else
                    {
                        return;
                    }
                }
            }



            bool value = true;
            if (!string.IsNullOrEmpty(txtPName.Text.Trim()))
            {

                string inputCategoryName = txtPName.Text.Trim().ToLower();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string qry = "SELECT * FROM Product WHERE LOWER(ProductName) = @name and CategoryId=@id";
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        cmd.Parameters.AddWithValue("@name", txtPName.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", categoryId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {

                                value = false;
                                errname.Text = "Product is already Added";

                            }
                            else
                            {

                                name = txtPName.Text.Trim();

                            }
                        }
                    }
                }

            }
            else
            {
                value = false;
                errname.Text = "enter valid Service";
            }




            if (value == true)
            {


                string query = "INSERT INTO Product (ProductName, Description, Price, Stock, ImagePath, CategoryId ) VALUES (@Name, @Description, @Price, @Stock, @ImagePath, @Category)";


                try
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {

                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@Description", description);
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.Parameters.AddWithValue("@Stock", stock);
                            cmd.Parameters.AddWithValue("@Category", categoryId);
                            cmd.Parameters.AddWithValue("@ImagePath", imagePath);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            HttpContext.Current.Response.Write("<script>alert('Product Add Successfullyy!!!!!');</script>");

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
        private string UploadImage()
        {
            string fileName = Path.GetFileName(filePImage.PostedFile.FileName);

            string imagePath = Server.MapPath("~/admin/Images/" + fileName);
          
            filePImage.PostedFile.SaveAs(imagePath);
        
            return imagePath;
        }



        private void ClearFields()
        {
           
           txtPName.Text = "";
            txtPDescription.Text = "";
            txtPPrice.Text = "";
            txtPStock.Text = "";
            ddlCategory.Items.Clear();
            ddlProductType.SelectedIndex = 0;
        }

    }
}
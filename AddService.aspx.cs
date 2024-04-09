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
    public partial class AddService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearFields();  
            }

        }

        protected void ddlServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string serviceType = ddlServiceType.SelectedValue;
            PopulateServiceCategories(serviceType);
        }

        private void PopulateServiceCategories(string serviceType)
        {
            string connectionString = "Data Source=NUPUR;Initial Catalog=salon;Integrated Security=True";
            string query = "SELECT CategoryName FROM ServiceCategory WHERE CType = @serviceType";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@serviceType", serviceType);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ddlServiceCategory.Items.Clear();
                        while (reader.Read())
                        {
                            string categoryName = reader["CategoryName"].ToString();
                            ddlServiceCategory.Items.Add(new ListItem(categoryName, categoryName));
                        }
                    }
                }
            }
        }

        protected void btnAddService_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=NUPUR;Initial Catalog=salon;Integrated Security=True";
            string serviceType = ddlServiceType.SelectedValue;
            string serviceName = "";
            string serviceCategoryName = ddlServiceCategory.SelectedItem.Text; 

            int categoryId;
           
            string query = "SELECT CategoryID FROM ServiceCategory WHERE CategoryName = @CategoryName and CType=@type";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", serviceCategoryName);
                    command.Parameters.AddWithValue("@type", serviceType);
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
            if (!string.IsNullOrEmpty(txtServiceName.Text.Trim()))
            {

                string inputCategoryName = txtServiceName.Text.Trim().ToLower();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string qry = "SELECT * FROM Service WHERE LOWER(ServiceName) = @name and CategoryId=@id";
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        cmd.Parameters.AddWithValue("@name", txtServiceName.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", categoryId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {

                                value = false;
                                errname.Text = "Service is already Added";

                            }
                            else
                            {

                                serviceName= txtServiceName.Text.Trim();

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

            string description = txtDescription.Text.Trim();
            decimal price = decimal.Parse(txtPrice.Text.Trim());

            if (value == true)
            {


                string query1 = "INSERT INTO Service(ServiceName, CategoryId, Description, price) VALUES (@Name, @Categoryid, @des, @price)";


                try
                {

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query1, connection))
                        {


                            command.Parameters.AddWithValue("@Name", serviceName);
                            command.Parameters.AddWithValue("@Categoryid", categoryId);
                            command.Parameters.AddWithValue("@des", description);
                            command.Parameters.AddWithValue("@price", price);

                            connection.Open();
                            command.ExecuteNonQuery();
                            HttpContext.Current.Response.Write("<script>alert('Service Add Successfullyy!!!!!');</script>");
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

            txtServiceName.Text = "";
            ddlServiceCategory.SelectedItem.Text="";
            ddlServiceType.SelectedIndex = 0;
            txtDescription.Text = "";
            txtPrice.Text = "";
            errname.Text = "";
            txterror.Text = "";
        }
    }
}
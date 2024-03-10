using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salon
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                Response.Redirect("welcome.aspx");
            }

        }

        protected void btnclick_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RN6L47F\\SQLEXPRESS;Initial Catalog=Nursery;Integrated Security=True ";
            string name = "", hashpass="", namerr = "", contacterr = "", emailerr="",agerr="",passeerr="",genderr="" ;
            bool value = true;
            if (!string.IsNullOrEmpty(txtname.Text.Trim()))
            {
                name = txtname.Text.Trim();
            }
            else
            {
                value = false;
            }
            int contact = 0;
            if (!string.IsNullOrEmpty(txtcontact.Text.Trim()) || txtcontact.Text.Length != 10)
            {
                contact=int.Parse(txtcontact.Text.Trim());
            }
            else
            {
                value = false;
                contacterr = "contact should be of 10 digits";
            }

            int age = 0;
            if (!string.IsNullOrEmpty(txtcontact.Text.Trim()) )
            {
                age = int.Parse(txtage.Text.Trim());
            }
            else
            {
                value = false;
            }


            string gender = "";
            if(rbmale.Checked)
            {
                gender=rbmale.Text;

            }
            else if(rbfemale.Checked)
            {
                gender=rbfemale.Text;   
            }
            else
            {
                value = false;
                genderr = "please select gender";
            }

            string email="";
            if (!string.IsNullOrEmpty(txtemail.Text.Trim()))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string qry = "SELECT * FROM reg WHERE email = @email";
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        cmd.Parameters.AddWithValue("@email", txtemail.Text.Trim());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                
                                value = false;
                                emailerr = "email is already register";
                            }
                            else
                            {
                                
                                email = txtemail.Text.Trim();
                            }
                        }
                    }
                }
            }
            else
            {
                
                value = false;
            }

            string pass ="";
            string conpass = "";
            if (!string.IsNullOrEmpty(txtpass.Text.Trim()) || txtpass.Text.Length >= 15 || txtpass.Text.Length <= 8)
            {
                pass=txtpass.Text.Trim();
                hashpass = Hashedpassword(pass);
                conpass=txtpass.Text.Trim();
            }else
            {
                value = false;
                passeerr = "password should be more than 8 characters and less than 15 characters";

            }
            if (value==true)
            {

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();


                        string query = "insert into reg (name,contact,age,gender,email, pass) VALUES (@name, @contact,@age,@gender,@email,@pass);"+ "SELECT SCOPE_IDENTITY();";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@contact", contact);
                            cmd.Parameters.AddWithValue("@age", age);
                            cmd.Parameters.AddWithValue("@gender", gender);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@pass", hashpass);







                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                int newUserId = Convert.ToInt32(cmd.ExecuteScalar());

                                
                                Session["uid"] = newUserId;
                                Response.Redirect("welcome.aspx");
                            }
                            else
                            {
                                
                                Response.Write("No rows were affected.");
                            }


                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                }
            }
            else
            {
                string error = "error" +namerr+"\n"+emailerr+"\n"+contacterr+"\n"+genderr+"\n"+passeerr;
                txterror.Text = error;
            }
            
            

        }

        private string Hashedpassword(string pass)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
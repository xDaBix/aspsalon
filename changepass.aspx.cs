
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salon_Management_System
{
    public partial class changepass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Session["uid"]);
            
            //if (Session["uid"] == null)
            //{
            //    Response.Redirect("login.aspx");
          //  }

        }

        protected void btnchangepass_Click(object sender, EventArgs e)
        {
            //string email = txtemail.Text;
            string newpass = Hashedpassword(txtnewpass.Text); // Corrected the method name
            string connectionString = "Data Source=DESKTOP-OE4JH70\\SQLEXPRESS;Initial Catalog=Salon;Integrated Security=True ";
            //int id = (int)Session["uid"];

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    object count=null;
                    String password = Hashedpassword(txtOldPass.Text);
                    con.Close();
                    con.Open();
                    string qry = "select * from tblRegistration where password=@password";

                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {

                        cmd.Parameters.AddWithValue("@Password", password);

                        // Execute the query
                        try
                        {
                            count = cmd.ExecuteScalar();
                        }catch(Exception ex) { Response.Write("Ex:Incorrect Old Password!"); }
                        con.Close();
                        // If count > 0, user exists and credentials are correct

                    }

                    if (count != null)
                    {
                        Response.Write("Old pass is Correct");

                        con.Close();
                        con.Open(); // Added this line to open the connection

                        string qry2 = "update tblRegistration set password=@newpass where ID=id";

                        using (SqlCommand cmd = new SqlCommand(qry2, con))
                        {
                            cmd.Parameters.AddWithValue("@newpass", newpass); // Corrected the parameter names
                                                                              //cmd.Parameters.AddWithValue("@email", email);

                            cmd.ExecuteNonQuery();

                        }
                        con.Close();
                        Response.Write("password updated successfully!");
                        Response.Redirect("login.aspx");
                    } else
                    {
                        Response.Write("Incorrect Old Password!");
                    }
              
                    }
                }





                
            catch (Exception ex)
            {
                Response.Write(ex);
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

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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            string password = hashpassword(txtpass.Text);
            string connectionString = "Data Source=DESKTOP-RN6L47F\\SQLEXPRESS;Initial Catalog=Nursery;Integrated Security=True ";
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string qry = "select *from reg where email=@email and pass=@pass";
                    using(SqlCommand cmd = new SqlCommand(qry, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pass", password);
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);
                                Session["uid"]=id;
                                Response.Redirect("welcome.aspx");
                            }
                        }

                    }
                }

            }catch (Exception ex)
            {

            }
        }

        private string hashpassword(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
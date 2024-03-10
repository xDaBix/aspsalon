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
    public partial class changepass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void btnchangepass_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            string newpass = Hashedpassword(txtnewpass.Text); // Corrected the method name

            string connectionString = "Data Source=DESKTOP-RN6L47F\\SQLEXPRESS;Initial Catalog=Nursery;Integrated Security=True ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open(); // Added this line to open the connection

                string qry = "update reg set pass=@newpass where email=@email";

                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {
                    cmd.Parameters.AddWithValue("@newpass", newpass); // Corrected the parameter names
                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.ExecuteNonQuery();
                }
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
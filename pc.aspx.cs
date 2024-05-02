using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CAT
{
    public partial class pc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindpc();
            }
        }

        private void bindpc()
        {
            string connectionString = "Data Source=DESKTOP-EVLGQHH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string query = "SELECT * FROM pc";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        ProductRepeater.DataSource = dt;
                        ProductRepeater.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace imagestore
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                DisplayStoredImage();
            }

        }

        protected void storeimg_Click(object sender, EventArgs e)
        {
            if (img.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(img.FileName);
                    string imgpath = "~/images/" + filename;
                    img.SaveAs(Server.MapPath(imgpath));
                    string connectionstring = "Data Source=DESKTOP-EVLGQHH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
                    string query = "INSERT INTO tblimg(imgname,imglocation) VALUES(@imgname,@imglocation)";
                    using (SqlConnection con = new SqlConnection(connectionstring))
                    {
                        con.Open();
                        using(SqlCommand cmd=new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@imgname",filename);
                            cmd.Parameters.AddWithValue("@imglocation",imgpath);
                            cmd.ExecuteNonQuery();
                            Response.Redirect("Default.aspx");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        private void DisplayStoredImage()
        {
            string connectionstring = "Data Source=DESKTOP-EVLGQHH\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string query = "SELECT imglocation FROM tblimg"; 
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            string imgPath = (string)reader["imglocation"];
                            Image imgControl = new Image();
                            imgControl.ImageUrl = ResolveUrl(imgPath);
                            imgControl.CssClass = "stored-image"; 
                            imgControl.Width = 200; 
                            imgControl.Height = 200; 
                            form1.Controls.Add(imgControl);
                        }
                    }
                }
            }
        }
    }
}
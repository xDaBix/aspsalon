using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salon_Management_System
{
    public partial class welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session["uid"]);
            // lblUID.Text = Session["uid"].ToString();
            if (Session["uid"] == null)
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void changepassowrd_Click(object sender, EventArgs e)
        {
            Response.Redirect("changepass.aspx");
        }
    }
}
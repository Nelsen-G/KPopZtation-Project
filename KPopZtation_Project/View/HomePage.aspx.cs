using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project.View
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && Session["user"].ToString() == "Customer")
            {
                if (Session["username"] != null)
                {
                    lblWelcomeMessage.Text = "Welcome, " + Session["username"].ToString();
                }
            }
        }
    }
}
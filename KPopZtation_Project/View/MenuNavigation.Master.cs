using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project
{
    public partial class MenuNavigation : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnProduct_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {

        }

        protected void btnTransactions_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();

            Response.Redirect("LoginPage.aspx");
        }

        protected void btnTransactionReport_Click(object sender, EventArgs e)
        {

        }


        //Sementara begini dulu ya
        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["user"] = "Admin";
            Response.Redirect("HomePage.aspx");
        }
    }
}
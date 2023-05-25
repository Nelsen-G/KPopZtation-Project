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


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartPage.aspx");
        }
    
        protected void btnTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionsPage.aspx");
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfile.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();

            if (Request.Cookies["LoggedInUser"] != null)
            {
                HttpCookie loginCookie = new HttpCookie("LoggedInUser");
                loginCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(loginCookie);
            }


            Response.Redirect("LoginPage.aspx");
        }

        protected void btnTransactionReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionReportPage.aspx");
        }


        //Sementara begini dulu ya
        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["user"] = "Admin";
            Response.Redirect("HomePage.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

    }
}
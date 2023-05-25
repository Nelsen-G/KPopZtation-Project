using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project.View
{
    public partial class TransactionsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TransactionsRepository transactionsRepository = new TransactionsRepository();

            if (!IsPostBack)
            {
                
                List<object> transactions = transactionsRepository.GetTransactions();

                rptTransactions.DataSource = transactions;
                rptTransactions.DataBind();
            }
        }
    }
}
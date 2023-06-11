using KPopZtation_Project.Dataset;
using KPopZtation_Project.Handler;
using KPopZtation_Project.Model;
using KPopZtation_Project.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KPopZtation_Project.View
{
    public partial class TransactionReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            KPopZtationReport report = new KPopZtationReport();

            CrystalReportViewer1.ReportSource = report;
            DataSetKPop data = getData(TransactionHandler.GetTransactions());
            report.SetDataSource(data);

        }

        private DataSetKPop getData(List<TransactionHeader> transactions)
        {
            DataSetKPop data = new DataSetKPop();

            var headertable = data.TransactionHeader;
            var detailtable = data.TransactionDetail;


            foreach (TransactionHeader t in transactions)
            {
                var hrow = headertable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["CustomerID"] = t.CustomerID;
                headertable.Rows.Add(hrow);

                foreach (TransactionDetail d in t.TransactionDetails)
                {
                    var drow = detailtable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["AlbumName"] = d.Album.AlbumName;
                    drow["Qty"] = d.Qty;
                    drow["AlbumStock"] = d.Album.AlbumStock;
                    drow["AlbumPrice"] = d.Album.AlbumPrice;
                    detailtable.Rows.Add(drow);
                }
            }
            return data;
        }
    }
}
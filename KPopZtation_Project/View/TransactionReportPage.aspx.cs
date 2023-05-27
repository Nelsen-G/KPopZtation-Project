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
            TransactionCrystalReport report = new TransactionCrystalReport();

            CrystalReportViewer1.ReportSource = report;
            DataSetKPop data = getData(TransactionHandler.GetTransactions(), AlbumHandler.GetAlbums());
            report.SetDataSource(data);

        }

        private DataSetKPop getData(List<TransactionHeader> transactions, List<Album> albums)
        {
            DataSetKPop data = new DataSetKPop();

            var headertable = data.TransactionHeader;
            var detailtable = data.TransactionDetail;
            var albumtable = data.Album;

            decimal grandTotal = 0; // Variable to store the grand total

            foreach (TransactionHeader t in transactions)
            {
                decimal subTotal = 0; // Variable to store the sub total for each transaction

                var hrow = headertable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["CustomerID"] = t.CustomerID;

                headertable.Rows.Add(hrow);

                foreach (TransactionDetail d in t.TransactionDetails)
                {
                    var drow = detailtable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["AlbumID"] = d.AlbumID;
                    drow["Qty"] = d.Qty;

                    detailtable.Rows.Add(drow);

                    // Calculate the subtotal for each transaction detail
                    Album album = albums.FirstOrDefault(a => a.AlbumID == d.AlbumID);
                    if (album != null)
                    {
                        decimal albumPrice = album.AlbumPrice;
                        decimal quantity = d.Qty;
                        decimal subtotal = albumPrice * quantity;
                        subTotal += subtotal;
                    }
                }

                // Update the sub total value for the transaction header
                hrow["SubTotal"] = subTotal;

                grandTotal += subTotal; // Add the sub total to the grand total
            }

            // Set the grand total value for the dataset
            data.Tables["GrandTotal"].Rows.Add(grandTotal);

            return data;
        }

    }
}
using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Factory
{
    public class TransactionsFactory
    {

        public TransactionHeader CreateTransactionHeader(int customerID, DateTime transactionDate)
        {
            TransactionHeader th = new TransactionHeader();


            th.CustomerID = customerID;
            th.TransactionDate = transactionDate;
            

            return th;
        }


        public TransactionDetail CreateTransactionDetail(int transactionID, int albumID, int quantity)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionID = transactionID;
            td.AlbumID = albumID;
            td.Qty = quantity;
            

            return td;
        }




    }
}
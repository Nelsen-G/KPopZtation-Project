using KPopZtation_Project.Factory;
using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Repository
{
    public class TransactionsRepository
    {

        dbKPopEntities db = dbSingleton.getInstance();

        public TransactionHeader AddTransactionHeader(int customerID, DateTime transactionDate)
        {
            TransactionsFactory tf = new TransactionsFactory();

            TransactionHeader newTH = tf.CreateTransactionHeader(customerID, transactionDate);

            return newTH;
        }

        public TransactionDetail AddTransactionDetail(int transactionID, int albumID, int quantity)
        {
            TransactionsFactory tf = new TransactionsFactory();

            TransactionDetail newTD = tf.CreateTransactionDetail(transactionID, albumID, quantity);

            return newTD;
        }

        public void SaveTransaction(TransactionHeader transactionHeader, List<TransactionDetail> transactionDetails)
        {
            db.TransactionHeaders.Add(transactionHeader);
            db.TransactionDetails.AddRange(transactionDetails);
            db.SaveChanges();
        }


        public List<object> GetTransactions()
        {
            var transactions = (from th in db.TransactionHeaders
                                join td in db.TransactionDetails on th.TransactionID equals td.TransactionID
                                group new { td.AlbumID, td.Album.AlbumName, td.Qty, td.Album.AlbumPrice, td.Album.AlbumImage }
                                by new { th.TransactionID, th.TransactionDate, th.CustomerID, th.Customer.CustomerName } into g
                                select new
                                {
                                    TransactionID = g.Key.TransactionID,
                                    TransactionDate = g.Key.TransactionDate,
                                    CustomerID = g.Key.CustomerID,
                                    CustomerName = g.Key.CustomerName,
                                    Albums = g.ToList()
                                }).ToList<object>();

            return transactions;
        }



    }
}
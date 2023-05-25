using KPopZtation_Project.Model;
using KPopZtation_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Handler
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> TransactionRepository { get; private set; }

        public static List<TransactionHeader> GetTransactions()
        {
            return TransactionsRepository.GetTransactionsFromRepo();
        }

    }
}
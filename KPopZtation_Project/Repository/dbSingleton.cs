using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Repository
{
    public class dbSingleton
    {

        private static DatabaseKPopEntities1 db = null;

        private dbSingleton() { }

        public static DatabaseKPopEntities1 getInstance()
        {
            if (db == null)
            {
                db = new DatabaseKPopEntities1();
            }

            return db;
        }

    }
}
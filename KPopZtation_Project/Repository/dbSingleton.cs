using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Repository
{
    public class dbSingleton
    {

        private static DatabaseKPopEntities2 db = null;

        private dbSingleton() { }

        public static DatabaseKPopEntities2 getInstance()
        {
            if (db == null)
            {
                db = new DatabaseKPopEntities2();
            }

            return db;
        }

    }
}
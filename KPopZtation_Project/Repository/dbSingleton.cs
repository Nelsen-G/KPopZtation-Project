using KPopZtation_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPopZtation_Project.Repository
{
    public class dbSingleton
    {

        private static dbKPopEntities db = null;

        private dbSingleton() { }

        public static dbKPopEntities getInstance()
        {
            if (db == null)
            {
                db = new dbKPopEntities();
            }

            return db;
        }

    }
}
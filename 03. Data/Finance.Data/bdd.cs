using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Finance.Data.bdd
{
    public abstract class bdd
    {
        protected string connectionString;

        public bdd()
        {
            this.connectionString = @"Data Source=LT-SOD00005718\MSSQLSERVER2014;Initial Catalog=Finance;User Id=sa;Password=N3tapsys;MultipleActiveResultSets=True;Application Name=EntityFramework";
            //this.connectionString = "Server = tcp:tatabdd.database.windows.net,1433; Initial Catalog = Finance; Persist Security Info = False; User ID=tatawi; Password =azure1452.Pouet; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        }

    }
}
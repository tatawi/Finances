﻿using System;
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
            //this.connectionString = @"Data Source=127.0.0.1,1433;Initial Catalog=Finance;User Id=sa;Password=1452.Pouet;MultipleActiveResultSets=True;Application Name=EntityFramework";
            this.connectionString = @"Data Source=LT-SOD00005718\MSSQLSERVER2014;Initial Catalog=Finance2;User Id=sa;Password=N3tapsys;MultipleActiveResultSets=True;Application Name=EntityFramework";

        }


    }
}
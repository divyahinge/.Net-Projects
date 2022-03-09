using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ORMBasedApp.Models;
using System.Data.Entity;
using MySql.Data.EntityFramework;

namespace ORMBasedApp.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DbORMContext : DbContext
    {
        public DbSet<Book> Book { get; set; }

        public DbORMContext() : base("mysqldb")
        {

        }
    }
}
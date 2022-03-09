using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AuthorizedApp.Models;
using MySql.Data.EntityFramework;

namespace AuthorizedApp.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DbORMContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbORMContext():base("mysqldb")
        {

        }
    }
}
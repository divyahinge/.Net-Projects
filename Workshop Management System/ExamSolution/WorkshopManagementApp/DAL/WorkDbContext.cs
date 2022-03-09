using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.EntityFramework;
using WorkshopManagementApp.Models;

namespace WorkshopManagementApp.DAL
{
    
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WorkDbContext : DbContext
    {
       

        public WorkDbContext() : base("mysqldb")
        {

        }
        public DbSet<Workshop> Workshops { get; set; }
    }
}
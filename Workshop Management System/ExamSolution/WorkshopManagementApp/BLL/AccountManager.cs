using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkshopManagementApp.BLL
{
    public class AccountManager
    {
        public static bool Validate(string id, string password)
        {
            bool status = false;
            if ( id == "admin@iet.com" && password == "Administrator")
            {
                status = true;
            }

            return status;
        }
    }
}
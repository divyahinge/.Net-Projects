using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthorizedApp.DAL;
using AuthorizedApp.Models;

namespace AuthorizedApp.BLL
{
    public class AccountManager
    {
        static DbORMContext entities = new DbORMContext();
        public static bool IsValid(string username , string pwd)
        {
            bool status = false;
            List<User> users = entities.User.ToList();
            foreach(User us in users)
            {
                if(us.UserName == username && us.Password == pwd)
                {
                    status = true;
                }
            }
            return status;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknolojiKovaniWebApi.Domain.Users
{
    public class UsersDomain
    {
        internal bool SaveUsers(DTOs.External.Users User)
        {
            try
            {
                tKovanContext ctx = new tKovanContext();
                Models.EntityClass.Users eUsers = new Models.EntityClass.Users();
                eUsers.Email = User.Email;
                eUsers.Password = User.Password;
                eUsers.PhoneNumber = User.PhoneNumber;
                eUsers.UserName = User.UserName;
                ctx.Users.Add(eUsers);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        internal DTOs.External.Users Login(DTOs.External.Users User)
        {
            DTOs.External.Users users = new DTOs.External.Users();
            
        }
    }
}

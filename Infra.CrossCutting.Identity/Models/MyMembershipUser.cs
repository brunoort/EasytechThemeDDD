using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
namespace Infra.CrossCutting.Identity.Models
{
    public class MyMembershipUser : MembershipUser
    {
        public MyMembershipUser(long userId, string userName, string email)
            : base(Membership.Provider.Name, userName, userId, email, null, null, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
        }
    }
}
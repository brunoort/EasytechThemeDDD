using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCutting.Identity.Models
{
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public bool IsInRole(string role)
        {
            if (String.Compare(role, "admin", true) == 0)
            {
                return (Identity.Name == "JustinEtheredge");
            }
            else
            {
                return false;
            }
        }

        public IIdentity Identity
        {
            get; private set;
        }
    }
}

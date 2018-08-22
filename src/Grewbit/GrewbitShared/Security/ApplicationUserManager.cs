using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrewbitShared.Models;
using Microsoft.AspNet.Identity;

namespace GrewbitShared.Security
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> userStore)
            : base(userStore)
        {
        }
    }
}

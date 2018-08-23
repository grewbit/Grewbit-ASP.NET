using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrewbitShared.Models;

namespace GrewbitShared.Data
{
    public class UserProfileRepository : BaseRepository<UserProfile>
    {
        public UserProfileRepository(Context context) : base(context)
        {
        }

        public UserProfile Get(string userId)
        {
            return Context.UserProfiles.SingleOrDefault(up => up.UserId == userId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrewbitShared.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GrewbitShared.Data
{
    public class Context : IdentityDbContext<User>
    {
        public DbSet<Plot> Plots { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public Context() : base("Context")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

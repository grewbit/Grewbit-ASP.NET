using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrewbitShared.Models;

namespace GrewbitShared.Data
{
    public class PlotRepository : BaseRepository<Plot>
    {
        public PlotRepository(Context context) : base(context)
        {
        }

        public Plot Get(int id, string userId)
        {
            return Context.Plots
                .Where(p => p.Id == id && p.UserId == userId)
                .SingleOrDefault();
        }

        public IList<Plot> GetList(string userId)
        {
            return Context.Plots
                .Where(p => p.UserId == userId)
                .OrderBy(p => p.Id)
                .ToList();
        }

        public bool PlotOwnedByUserId(int id, string userId)
        {
            return Context.Plots
                .Where(p => p.Id == id && p.UserId == userId)
                .Count() == 1;
        }
    }
}

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

        public IList<Plot> GetList()
        {
            return Context.Plots.OrderBy(p => p.Id).ToList();
        }
    }
}

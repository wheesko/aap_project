using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSeer
{
    public interface MatchesForm
    {
        Action Back { get; set; }
        Action Exit { get; set; }
        Action Next { get; set; }
        Action Previous { get; set; }
        Action Searh { get; set; }
    }
}

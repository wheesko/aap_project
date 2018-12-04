using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSeer
{
    interface OptionForm
    {
        Action Upload{ get; set; }
        Action Back { get; set; }
        Action Exit { get; set; }
    }
}

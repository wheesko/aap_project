using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSeer
{
    public interface RegisterIUI
    {
        Action Exit { get; set; }
        Action Registers { get; set; }
        Action Back { get; set; }
    }
}

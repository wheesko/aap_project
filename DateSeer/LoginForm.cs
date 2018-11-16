using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSeer
{
    public interface LoginForm
    {
        Action Logins { get; set; }
        Action Register { get; set; }
        Action Exit { get; set; }
        Action facebook { get; set; }
    }
}

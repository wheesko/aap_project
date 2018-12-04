using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSeer
{
    public interface MainForm
    {
        Action LikeButtomPressed { get; set; }
        Action DisLikeButtomPressed { get; set; }
        Action AllMatches { get; set; }
        Action Profile { get; set; }
        Action Exit { get; set; }

    }
}

using MobileApp.Models;
using MobileApp.Views;

namespace MobileApp
{
    internal class MatchesController
    {
        private MatchesForm match;
        private User mainUser;

        public MatchesController(MatchesForm match, User mainUser)
        {
            this.match = match;
            this.mainUser = mainUser;
            match.BackPressed += () => match.Back(mainUser);
        }
    }
}
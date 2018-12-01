using MobileApp.Models;

namespace MobileApp
{
    internal class MainController
    {
        private MainPage main;
        private User mainUser;

        public MainController(MainPage main)
        {
            this.main = main;
        }

        public MainController(MainPage main, User mainUser)
        {
            this.main = main;
            this.mainUser = mainUser;

        }
    }
}
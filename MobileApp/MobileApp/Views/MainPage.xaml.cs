using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        public Action<User> ProfilePressed = delegate { };
        public Action<User> MatchesPressed = delegate { };
        public Action Profile = delegate { };
        public Action Matches = delegate { };
        public Action LikePressed = delegate { };
        public Action DislikePressed = delegate { };

		public MainPage ()
		{
			InitializeComponent ();
		}

        private void Profile_Clicked(object sender, EventArgs e)
        {
            Profile();
        }
        private void Matches_Clicked(object sender, EventArgs e)
        {
            Matches();
        }

        private void Dislike_Clicked(object sender, EventArgs e)
        {
            DislikePressed();
        }

        private void Like_Clicked(object sender, EventArgs e)
        {
            LikePressed();
        }
    }
}
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
	public partial class MatchesPage : ContentPage
	{
        public Action<User> Back = delegate { };
        public Action BackPressed = delegate { };
        public Action NextPressed = delegate { };
        public Action PreviousPressed = delegate { };
        public Action Search = delegate { };

		public MatchesPage ()
		{
			InitializeComponent ();
		}

        private void SearchByName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            NextPressed();
        }

        private void Previous_Clicked(object sender, EventArgs e)
        {
            PreviousPressed();
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            BackPressed();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class MainPage : ContentPage,IDisposable
    {
        public Action ProfilePressed = delegate { };
        public Action MatchesPressed = delegate { };
        public Action DislikePressed = delegate { };
        public Action LikePressed = delegate { };

        public MainPage()
        {
            InitializeComponent();
        }

        private void Profile_Clicked(object sender, EventArgs e)
        {
            ProfilePressed();
        }

        private void Matches_Clicked(object sender, EventArgs e)
        {
            this.Dispose();
            MatchesPressed();
        }

        private void Dislike_Clicked(object sender, EventArgs e)
        {

        }

        private void Like_Clicked(object sender, EventArgs e)
        {

        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}

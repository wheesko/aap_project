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
	public partial class ProfileForm : ContentPage
	{
        public Action<User> Back = delegate { };
        public Action BackPressed = delegate { };
        public Action UploadPhoto = delegate { };

		public ProfileForm ()
		{
			InitializeComponent ();
		}

        private void Back_Clicked(object sender, EventArgs e)
        {
            BackPressed();
        }

        private void Upload_Clicked(object sender, EventArgs e)
        {
            UploadPhoto();
        }
    }
}
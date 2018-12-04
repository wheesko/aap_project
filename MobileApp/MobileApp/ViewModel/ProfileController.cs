using System;
using MobileApp.Models;
using MobileApp.Views;

namespace MobileApp
{
    internal class ProfileController
    {
        private ProfileForm prof;
        private User MainUser;

        public ProfileController(ProfileForm prof, User mainUser)
        {
            this.prof = prof;
            this.MainUser = mainUser;
            prof.BackPressed += () => prof.Back(mainUser);
            prof.UploadPhoto += () => UploadPicture();
            Profile_load();

        }

        private void UploadPicture()
        {
           // reik padaryt kad paiimtu nuotrauka ir idetu i db 
        }
        private void Profile_load()
        {
            prof.Name.Text = MainUser.name;
            prof.UserImage.Source = MainUser.image;
        }
    }
}
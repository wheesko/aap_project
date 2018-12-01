using System;
using MobileApp.Models;
using MobileApp.Views;

namespace MobileApp
{
    internal class ProfileController
    {
        private ProfileForm prof;
        private User mainUser;

        public ProfileController(ProfileForm prof, User mainUser)
        {
            this.prof = prof;
            this.mainUser = mainUser;
            prof.BackPressed += () => prof.Back(mainUser);
            prof.UploadPhoto += () => UploadPicture();
        }

        private void UploadPicture()
        {
            throw new NotImplementedException();
        }
    }
}
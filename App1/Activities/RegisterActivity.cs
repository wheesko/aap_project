using System;
using Android.App;
using Android.Content;
using Android.OS;


namespace App1
{
    [Activity(Label = "Register DatesSeer")]
    public class RegisterActivity: Activity
    {
    
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "Register" layout
            SetContentView(Resource.Layout.Register);

            var btnRegister = FindViewById(Resource.Id.Register);
            var btnBack = FindViewById(Resource.Id.Back);

            btnRegister.Click += btnRegister_Clicked;
            btnBack.Click += btnBack_Clicked;
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
          //  Intent nextActivity = new Intent(this, typeof(LoginActivity));
          //  StartActivity(nextActivity);
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
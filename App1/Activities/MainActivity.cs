using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;
using App1.Code.Controller;
using App1.Activities;

namespace App1
{
    [Activity(Label = "DateSeer", MainLauncher = true)]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.Login);

            var intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
            Finish();
            

        }

        private void btnfbLogin_Clicked(object sender, EventArgs e)
        {
          
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
        
        }
        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this,typeof(RegisterActivity));
            StartActivity(nextActivity); 
        }
    }
}
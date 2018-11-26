using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1.Activities
{
    public class LoginActivity:Activity
    {
        private Button _ButtonLogin;
        private Button _ButtonRegister;
        private EditText _username;
        private EditText _password;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);

          
            _ButtonLogin = FindViewById<Button>(Resource.Id.btnLoginLogin);
            _ButtonRegister = FindViewById<Button>(Resource.Id.btnRegisterLogin);
            _username = FindViewById<EditText>(Resource.Id.UsernameTextLogin);
            _password = FindViewById<EditText>(Resource.Id.PasswordTextLogin);

            _ButtonLogin.Click += ButtonLogin;
            _ButtonRegister.Click += ButtonRegister;
        }

        private void ButtonRegister(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent);
        }

        private void ButtonLogin(object sender, EventArgs e)
        {
           
        }
    }
}
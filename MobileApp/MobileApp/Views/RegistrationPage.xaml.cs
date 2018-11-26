﻿using MobileApp.ViewModel;
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
    public partial class RegistrationPage : ContentPage
    {
        public static RegistrationPage instance;
        public RegistrationPage()
        {
            instance = this;
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }
    }
}
using App2.Controls.WithRenderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App2
{
    public partial class App : Application
    {

        public NavigationPageEx Navi { get; set; } = new NavigationPageEx(new MainPage());

        public App()
        {
            InitializeComponent();

            MainPage = Navi;
            Navi.MiddleTitleColor = Color.Black;

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

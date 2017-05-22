using App2.Controls.WithRenderer;

using Xamarin.Forms;

namespace App2
{
    public partial class App : Application
    {

        public NavigationPageEx NavigationEx => navigationPageEx;

        private NavigationPageEx navigationPageEx; 

        public App()
        {
            InitializeComponent();
            navigationPageEx = new NavigationPageEx(new MainPage());
            MainPage = navigationPageEx;
            NavigationEx.MiddleTitleColor = Color.Black;

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

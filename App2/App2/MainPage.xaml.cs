using System.Collections.Generic;
using Xamarin.Forms;

using DuGu.XFLib.Controls;

using App2.Helpers;
using App2.Views;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        List<TabViewChildren> Childrens;
        public MainPage()
        {
            InitializeComponent();
            Childrens = new List<TabViewChildren>()
            {
                new TabViewChildren()
                {
                    UnSelectImageSource = "",
                    SelectedImageSource = "icon.png",
                    SelectedTextColor = Color.Red,
                    ImageSize = new Size(25,25),
                    TextFontSize = 18,
                    Text = "主页",
                    UnSelectTextColor = Color.Gray,
                    View = new HomeView(),
                },
                new TabViewChildren()
                {
                    UnSelectImageSource = "",
                    SelectedImageSource = "icon.png",
                    SelectedTextColor = Color.Red,
                    ImageSize = new Size(25,25),
                    TextFontSize = 18,
                    Text = "主页",
                    UnSelectTextColor = Color.Gray,
                    View = new HomeView(),
                },
                new TabViewChildren()
                {
                    UnSelectImageSource = "",
                    SelectedImageSource = "icon.png",
                    SelectedTextColor = Color.Red,
                    ImageSize = new Size(25,25),
                    TextFontSize = 18,
                    Text = "主页",
                    UnSelectTextColor = Color.Gray,
                    View = new HomeView(),
                },
            };
            tabView.AddChildrenViews(Childrens);
            tabView.SelectedChanged += tabView_SelectedChanged;

        }

        private void tabView_SelectedChanged(object sender, TabViewChangedEventArgs e)
        {
            Color color = Color.White;
            switch (e.Index)
            {
                case 0: color = Color.Black; break;
                case 1: color = Color.Red; break;
                case 2: color = Color.Blue; break;
            }
            var view = e.View;
            view.BackgroundColor = color;
            var app = AppHelper.CurrentApplication;
            app.NavigationEx.MiddleTitleText = e.Index.ToString();
            app.NavigationEx.MiddleTitleColor = color;
        }
    }
}

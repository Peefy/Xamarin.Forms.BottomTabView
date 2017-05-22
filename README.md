# Xamarin.Forms.BottomTabView
This is a BottomTabView with Xamarin.Forms,and now it has NavigationPageEx(Android) in it.
## BottomTabView
- 布局样例
```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    x:Class="App2.MainPage"
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:duguctrls="clr-namespace:DuGu.XFLib.Controls"
    xmlns:local="clr-namespace:App2">
    <duguctrls:TabView x:Name="tabView" />
</ContentPage>
```
- 使用样例
```c#
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
```

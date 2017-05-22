# Xamarin.Forms.BottomTabView_And_NavigationPageEx
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
    <duguctrls:TabView
        x:Name="tabView"
        TabBarColor="White"
        TabBarHeight="100"
        TabLineColor="Navy" />
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
- TabView属性方法说明

属性值/方法名/事件名|说明|补充|注意事项
---|---|---|---
（属性）TabBarColor|设置TabView底部tab导航栏的背景颜色|无|无
（属性）TabBarHeight|设置TabView底部tab导航栏的高度大小|无|无
（属性）TabLineColor|设置TabView底部tab导航栏与导航View的分界线颜色|无|无
（方法）AddChildrenViews|添加一个tab导航以及导航的view视图|无|无
（事件）SelectedChanged|当底部tab导航点击选择发生变化时引起的事件|点击同一tab导航按钮不会触发|无

## NavigationPageEx
- 使用样例
```c#
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
```
- NavigationPageEx属性方法说明

属性值/方法名/事件名|说明|补充|注意事项
---|---|---|---
（属性）MiddleTitleColor|设置toolbar中间文字的颜色|无|无
（属性）MiddleTitleText|设置toolbar中间文字的内容|无|无

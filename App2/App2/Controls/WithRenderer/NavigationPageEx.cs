using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App2.Controls.WithRenderer
{
    public class NavigationPageEx : NavigationPage
    {
        public NavigationPageEx(Page page):base(page)
        {

        }

        public NavigationPageEx()
        {

        }

        #region MiddleTitleColor

        public static readonly BindableProperty MiddleTitleColorProperty =
            BindableProperty.Create("MiddleTitleColor",
                typeof(Color),
                typeof(NavigationPageEx),
                Color.Red,
                propertyChanged: null);

        private static void MiddleTitleColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
           
        }
        public Color MiddleTitleColor
        {
            get { return (Color)GetValue(MiddleTitleColorProperty); }
            set
            {
                SetValue(MiddleTitleColorProperty, value);
            }
        }

        #endregion

        #region MiddleTitleText

        public static readonly BindableProperty MiddleTitleTextProperty =
            BindableProperty.Create("MiddleTitleText",
                typeof(string),
                typeof(NavigationPageEx),
                "Title",
                propertyChanged: null);

        private static void MiddleTitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }
        public string MiddleTitleText
        {
            get { return (string)GetValue(MiddleTitleTextProperty); }
            set
            {
                SetValue(MiddleTitleTextProperty, value);
            }
        }

        #endregion

    }
}

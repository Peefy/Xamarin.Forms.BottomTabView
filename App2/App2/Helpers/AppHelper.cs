using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App2.Helpers
{
    public static class AppHelper
    {
        public static App CurrentApplication
        {
            get
            {
                return Application.Current as App;
            }
        }
    }
}

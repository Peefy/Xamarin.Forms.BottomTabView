using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DuGu.XFLib.Behaviors;
using Xamarin.Forms;

namespace DuGu.XFLib.Controls
{
    public partial class TabbedImageLabelView : ContentView
    {
        string labelText = "主页";
        Color labelColor = Color.Gray;
        public RadioBehavior radioBehavior;
        private TabViewChildren tabViewChildren;
        public event EventHandler<EventArgs> IndexSelectedChanged;

        public TabbedImageLabelView(TabViewChildren tabViewChildren, RadioBehavior radioBehavior)
        {
            InitializeComponent();
            this.tabViewChildren = tabViewChildren;
            this.radioBehavior = radioBehavior;
            this.Behaviors.Add(radioBehavior);

            this.grid.RowDefinitions[0].Height = tabViewChildren.ImageSize.Height;
            this.image.HeightRequest = tabViewChildren.ImageSize.Height;
            this.image.WidthRequest = tabViewChildren.ImageSize.Width;
            this.label.FontSize = tabViewChildren.TextFontSize;

            this.LabelText = tabViewChildren.Text;
            this.ImageSource = tabViewChildren.UnSelectImageSource;

            var dataTrigger = new DataTrigger(typeof(TabbedImageLabelView))
            {
                Binding = new Binding()
                {
                    Source = radioBehavior,
                    Path = "IsChecked"
                },
                Value = true,
            };
            dataTrigger.Setters.Add(new Setter()
            {
                Property = LabelColorProperty,
                Value = tabViewChildren.SelectedTextColor
            });
            dataTrigger.Setters.Add(new Setter()
            {
                Property = ImageSourceProperty,
                Value = tabViewChildren.SelectedImageSource
            });

            this.Triggers.Add(dataTrigger);

            tabViewChildren.View.SetBinding(IsVisibleProperty, new Binding()
            {
                Source = radioBehavior,
                Path = "IsChecked"
            });

        }

        #region LabelColor

        public static readonly BindableProperty LabelColorProperty =
            BindableProperty.Create("LabelColor",
                typeof(Color),
                typeof(TabbedImageLabelView),
                Color.Gray,
                propertyChanged: LabelColorPropertyChanged);

        private static void LabelColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var tab = (TabbedImageLabelView)bindable;
            tab.label.TextColor = (Color)newValue;

        }
        public Color LabelColor
        {
            get { return (Color)GetValue(LabelColorProperty); }
            set
            {
                SetValue(LabelColorProperty, value);
            }
        }
        #endregion

        public string LabelText
        {
            get { return labelText; }
            set
            {
                labelText = value;
                label.Text = labelText;
            }
        }

        #region ImageSource
        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("ImageSource",
        typeof(string),
        typeof(TabbedImageLabelView),
        "Icon.png",
        propertyChanged: ImageSourcePropertyChanged);

        private static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var tab = (TabbedImageLabelView)bindable;
            tab.image.Source = (string)newValue;
            if((string)newValue == tab.tabViewChildren.SelectedImageSource)
            {
                tab.IndexSelectedChanged?.Invoke(tab, new EventArgs());
            }
        }

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set
            {
                SetValue(ImageSourceProperty, value);
            }
        }
        #endregion


    }

}

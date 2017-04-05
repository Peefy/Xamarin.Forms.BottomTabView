using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DuGu.XFLib.Behaviors;
using Xamarin.Forms;

namespace DuGu.XFLib.Controls
{
    public partial class TabView : Grid
    {
        #region 私有字段

        List<ContentView> Views;
        List<RadioBehavior> RadioBehaviors;

        #endregion

        #region 构造函数

        public TabView()
        {
            InitializeComponent();

            Views = new List<ContentView>();
            RadioBehaviors = new List<RadioBehavior>();
            //ItemsSource = new ObservableCollection<TabViewChildren>();
            //ItemsSource.CollectionChanged += ItemsSource_CollectionChanged;
        }

        public TabView(IList<TabViewChildren> Children)
        {
            InitializeComponent();

            Views = new List<ContentView>();
            RadioBehaviors = new List<RadioBehavior>();
            //ItemsSource = new ObservableCollection<TabViewChildren>();
            //ItemsSource.CollectionChanged += ItemsSource_CollectionChanged;

            for (int i = 0; i < Children.Count; ++i)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                RadioBehavior radioBehavior = new RadioBehavior() { IsChecked = i == 0 };
                TabViewChildren children = Children[i];
                Views.Add(children.View);
                RadioBehaviors.Add(radioBehavior);

                var tabbedView = new TabbedImageLabelView(children, radioBehavior)
                {
                    Margin = new Thickness(0, 3, 0, 0),
                };

                tabbedView.IndexSelectedChanged += (sendor, e) =>
                {
                    var view = sendor as TabbedImageLabelView;
                    int index = RadioBehaviors.IndexOf(view.radioBehavior);
                    SelectedChanged?.Invoke(this,
                        new TabViewChangedEventArgs(index, Children[index].View));
                };

                grid.Children.Add(tabbedView);
                viewGroup.Children.Add(children.View);
                SetColumn(tabbedView, i);
            }
        }

        #endregion

        #region 方法

        public void AddChildrenViews(IList<TabViewChildren> Children)
        {
            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            Views.Clear();
            RadioBehaviors.Clear();

            for (int i = 0; i < Children.Count; ++i)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                RadioBehavior radioBehavior = new RadioBehavior() { IsChecked = i == 0 };
                TabViewChildren children = Children[i];
                Views.Add(children.View);
                RadioBehaviors.Add(radioBehavior);
                var tabbedView = new TabbedImageLabelView(children, radioBehavior)
                {
                    Margin = new Thickness(0, 3, 0, 0),

                };

                tabbedView.IndexSelectedChanged += (sendor, e) =>
                {
                    var view = sendor as TabbedImageLabelView;
                    int index = RadioBehaviors.IndexOf(view.radioBehavior);
                    SelectedChanged?.Invoke(this,
                        new TabViewChangedEventArgs(index, ChildrenViews[index]));
                };

                grid.Children.Add(tabbedView);
                viewGroup.Children.Add(children.View);
                SetColumn(tabbedView, i);
            }
        }

        #endregion

        #region 事件

        public event EventHandler<TabViewChangedEventArgs> SelectedChanged;

        #endregion

        #region 属性

        #region TabLineColor

        public static readonly BindableProperty TabLineColorProperty =
            BindableProperty.Create("TabLineColor",
                typeof(Color),
                typeof(TabView),
                Color.FromHex("#eff0dc"),
                propertyChanged: TabLineColorPropertyChanged);

        private static void TabLineColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var tab = (TabView)bindable;
            tab.boxView.Color = (Color)newValue;

        }
        public Color TabLineColor
        {
            get { return (Color)GetValue(TabLineColorProperty); }
            set
            {
                SetValue(TabLineColorProperty, value);
            }
        }

        #endregion

        #region TabBarColor

        public static readonly BindableProperty TabBarColorProperty =
            BindableProperty.Create("TabBarColor",
                typeof(Color),
                typeof(TabView),
                Color.White,
                propertyChanged: TabBarColorPropertyChanged);

        private static void TabBarColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var tab = (TabView)bindable;
            tab.grid.BackgroundColor = (Color)newValue;

        }
        public Color TabBarColor
        {
            get { return (Color)GetValue(TabBarColorProperty); }
            set
            {
                SetValue(TabBarColorProperty, value);
            }
        }

        #endregion

        #region TabBarHeight

        public static readonly BindableProperty TabBarHeightProperty =
            BindableProperty.Create("TabBarHeight",
                typeof(int),
                typeof(TabView),
                60,
                propertyChanged: TabBarHeightPropertyChanged);

        private static void TabBarHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var tab = (TabView)bindable;
            tab.RowDefinitions[1].Height = (int)newValue;
            tab.tabbarGrid.RowDefinitions[1].Height = (int)newValue - 1;

        }
        public int TabBarHeight
        {
            get { return (int)GetValue(TabBarHeightProperty); }
            set
            {
                SetValue(TabBarHeightProperty, value);
            }
        }

        #endregion

        //#region ItemSource
        //public static readonly BindableProperty ItemsSourceProperty =
        //    BindableProperty.Create("ItemsSource",
        //    typeof(List<TabViewChildren>),
        //    typeof(TabView),
        //    new ObservableCollection<TabViewChildren>(),
        //    BindingMode.TwoWay,
        //    propertyChanged: ItemsSourceChanged);

        //public ObservableCollection<TabViewChildren> ItemsSource
        //{
        //    get
        //    {
        //        return (ObservableCollection<TabViewChildren>)this.GetValue(ItemsSourceProperty);
        //    }
        //    set
        //    {
        //        this.SetValue(ItemsSourceProperty, value);
        //    }
        //}

        //private void ItemsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    int i = 0;
        //    grid.Children.Clear();
        //    grid.ColumnDefinitions.Clear();
        //    Views.Clear();
        //    Behaviors.Clear();
        //    foreach (TabViewChildren item in e.NewItems)
        //    {

        //        grid.ColumnDefinitions.Add(new ColumnDefinition());
        //        RadioBehavior radioBehavior = new RadioBehavior() { IsChecked = i == 0 };
        //        TabViewChildren children = item;
        //        Views.Add(children.View);
        //        Behaviors.Add(radioBehavior);
        //        var tabbedView = new TabbedImageLabelView(children, radioBehavior)
        //        {
        //            Margin = new Thickness(0, 3, 0, 0),
        //        };
        //        tabbedView.IndexSelectedChanged += (sendor, ee) =>
        //        {
        //            var view = sendor as TabbedImageLabelView;
        //            int index = Behaviors.IndexOf(view.radioBehavior);
        //            SelectedChanged?.Invoke(this,
        //                new TabViewChangedEventArgs(index, ChildrenViews[index]));
        //        };
        //        grid.Children.Add(tabbedView);
        //        viewGroup.Children.Add(children.View);
        //        SetColumn(tabbedView, i);
        //        i++;
        //    }

        //    UpdateChildrenLayout();
        //    InvalidateLayout();
        //}

        //private static void ItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    if (!oldValue.Equals(newValue))
        //    {
        //        var tabview = (TabView)bindable;
        //        tabview.ItemsSource = (ObservableCollection<TabViewChildren>)newValue;
        //    }

        //}

        //#endregion

        #region ChildrenView

        public List<ContentView> ChildrenViews => Views;

        #endregion

        #endregion

    }

    public class TabViewChildren : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        ContentView view = new ContentView();
        string text = "tab1";
        string selectedImageSource = "icon.png";
        string unSelectImageSource = "icon.png";
        Color selectedTextColor = Color.Red;
        Color unSelectTextColor = Color.Default;
        Size imageSize = new Size(25,25);
        double textFontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));

        public ContentView View
        {
            get { return view; }
            set { SetProperty(ref view, value); }
        }

        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        public string SelectedImageSource
        {
            get { return selectedImageSource; }
            set { SetProperty(ref selectedImageSource, value); }
        }

        public string UnSelectImageSource
        {
            get { return unSelectImageSource; }
            set { SetProperty(ref unSelectImageSource, value); }
        }

        public Color SelectedTextColor
        {
            get { return selectedTextColor; }
            set { SetProperty(ref selectedTextColor, value); }
        }

        public Color UnSelectTextColor
        {
            get { return unSelectTextColor; }
            set { SetProperty(ref unSelectTextColor, value); }
        }

        public Size ImageSize
        {
            get { return imageSize; }
            set { SetProperty(ref imageSize, value); }
        }

        public double TextFontSize
        {
            get { return textFontSize; }
            set { SetProperty(ref textFontSize, value); }
        }

        object ViewModel { get; set; }

    }

    public class TabViewChangedEventArgs : EventArgs
    {
        public int Index { get; set; }
        public ContentView View { get; }
        public TabViewChangedEventArgs(int index,ContentView view)
        {
            Index = index;
            View = view;
        }
    }

}

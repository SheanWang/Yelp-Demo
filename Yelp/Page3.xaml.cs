using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Yelp
{
    public partial class Page3 : PhoneApplicationPage
    {
        System.Windows.Threading.DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();

        private struct AdInfo
        {
            public AdInfo(string image, string location, string phone, string title)
            {
                this.image = image;
                this.location = location;
                this.phone = phone;
                this.title = title;
            }

            public string image;
            public string location;
            public string phone;
            public string title;
        }

        AdInfo[] ads = new AdInfo[3]
        {
            new AdInfo("Assets/Ad1_Title.png", "1 km", "(202) 580-8889", "Mitchell's Fish Market"), 
            new AdInfo("Assets/Ad2_Title.png", "777 m", "(248) 646-3663", "Restaurant Reservations"), 
            new AdInfo("Assets/Ad3_Title.png", "1.5 km", "(010) 111222", "Rose's Luxury")
        };

        int i = 0;

        public Page3()
        {
            InitializeComponent();

            BuildAds();

            dt.Interval = new TimeSpan(0, 0, 0, 0, 5000); // 500 Milliseconds
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();
        }

        void dt_Tick(object sender, EventArgs e)
        {

            i %= 3;
            Title1.Text = ads[i].title;
            Phone1.Text = ads[i].phone;
            Location1.Text = ads[i].location;
            BitmapImage tn = new BitmapImage();
            tn.SetSource(Application.GetResourceStream(new Uri(ads[i].image, UriKind.Relative)).Stream);
            Image1.Source = tn;

            Title1.Visibility = System.Windows.Visibility.Visible;
            Phone1.Visibility = System.Windows.Visibility.Visible;
            Delete1.Visibility = System.Windows.Visibility.Visible;
            DeleteImage1.Visibility = System.Windows.Visibility.Visible;
            Location1.Visibility = System.Windows.Visibility.Visible;
            Image1.Visibility = System.Windows.Visibility.Visible;

            i++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative)); 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative)); 
        }

        private void BuildAds()
        {
            Title1.Visibility = System.Windows.Visibility.Collapsed;
            Phone1.Visibility = System.Windows.Visibility.Collapsed;
            Delete1.Visibility = System.Windows.Visibility.Collapsed;
            DeleteImage1.Visibility = System.Windows.Visibility.Collapsed;
            Location1.Visibility = System.Windows.Visibility.Collapsed;
            Image1.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Title1.Visibility = System.Windows.Visibility.Collapsed;
            Phone1.Visibility = System.Windows.Visibility.Collapsed;
            Delete1.Visibility = System.Windows.Visibility.Collapsed;
            DeleteImage1.Visibility = System.Windows.Visibility.Collapsed;
            Location1.Visibility = System.Windows.Visibility.Collapsed;
            Image1.Visibility = System.Windows.Visibility.Collapsed;

            dt.Stop();
        }
    }
}
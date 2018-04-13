using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IsItGoodApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LandingPage : Page
    {
        public LandingPageData LandingData { get; set; }

        public LandingPage()
        {
            this.InitializeComponent();

            this.LandingData = new LandingPageData();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                //this.Frame.GoBack();
                this.Frame.Navigate(typeof(SearchResults));
                
            }
            else
            {
                Frame.Navigate(typeof(MainPage));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var restaurant = (RestaurantModel)e.Parameter;

            LandingData.restaurant = restaurant;

            LandingData.LoadRestaurantDetails();

            if (LandingData.restaurant.ImageUrl != "x")
            {
                RestaurantImage.Source = new BitmapImage(new Uri(LandingData.restaurant.ImageUrl, UriKind.Absolute));
            }

            Run separatorRun = new Run
            {
                Text = ", "
            };

            for (int i = 0; i < LandingData.restaurant.Categories.Length; i++)
            {
                Run run = new Run
                {
                    Text = LandingData.restaurant.Categories[i].Title
                };
                tbCategories.Inlines.Add(run);

                if (i < LandingData.restaurant.Categories.Length -1)
                {
                    tbCategories.Inlines.Add(separatorRun);
                }
            }
        }

        private async void Exit_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog ExitDialog = new ContentDialog()
            {
                Title = "Exit?",
                Content = "Are you sure you want to exit?",
                PrimaryButtonText = "Exit",
                SecondaryButtonText = "Cancel"
            };

            ContentDialogResult exitResult = await ExitDialog.ShowAsync();

            if (exitResult == ContentDialogResult.Primary)
            {
                Application.Current.Exit();
            }
        }
    }
}

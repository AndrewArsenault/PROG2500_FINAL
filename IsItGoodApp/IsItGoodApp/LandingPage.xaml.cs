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
        /// <summary>
        /// Data for use on landing page
        /// </summary>
        public LandingPageData LandingData { get; set; }

        /// <summary>
        /// Default constructor for landing page.
        /// Initialize page and make new landing data
        /// </summary>
        public LandingPage()
        {
            this.InitializeComponent();

            this.LandingData = new LandingPageData();
        }

        //When back button is clicked, go back a page if possible.
        //if it's not, navigate back to main page
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.Navigate(typeof(SearchResults));
                
            }
            else
            {
                Frame.Navigate(typeof(MainPage));
            }
        }

        //when navigated to, call base navigated function
        //load landing data restaurant as a passed-in parameter
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var restaurant = (RestaurantModel)e.Parameter;

            LandingData.restaurant = restaurant;

            //load details
            LandingData.LoadRestaurantDetails();

            //if it has a url, set the image to that url
            if (LandingData.restaurant.ImageUrl != "x")
            {
                RestaurantImage.Source = new BitmapImage(new Uri(LandingData.restaurant.ImageUrl, UriKind.Absolute));
            }

            //Add each category to the categories text box separated by a comma
            for (int i = 0; i < LandingData.restaurant.Categories.Length; i++)
            {
                Run run = new Run
                {
                    Text = LandingData.restaurant.Categories[i].Title
                };
                tbCategories.Inlines.Add(run);

                if (i < LandingData.restaurant.Categories.Length -1)
                {
                    tbCategories.Inlines.Add(new Run
                    {
                        Text = ", "
                    });
                }
            }
        }

        //when exit click is pressed, ask user if they want to quit and then quit if desired
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace IsItGoodApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchResults : Page
    {

        RestaurantModel restaurant = (RestaurantModel)Application.Current.Resources["restaurant"];

        public SearchResults()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            ResultsList.ItemsSource = await Repository.GetAllSearchResults();
        }

        private void ResultsList_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var tb = (TextBlock)e.OriginalSource;
            var dataContext = tb.DataContext;

            restaurant = (RestaurantModel)dataContext;

            //Navigate to restaurant landing page
            Frame.Navigate(typeof(LandingPage), restaurant);
        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}

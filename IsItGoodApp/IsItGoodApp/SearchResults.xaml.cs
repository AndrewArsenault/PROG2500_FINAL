using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        private string _filter; //The filtered string, if it exists
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<RestaurantModel> RestaurantList { get; set; }
        private List<RestaurantModel> _allRestaurants = new List<RestaurantModel>();

        RestaurantModel restaurant = (RestaurantModel)Application.Current.Resources["restaurant"];

        public SearchResults()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            SearchData searchData = (SearchData)Application.Current.Resources["searchData"];

   
            RestaurantList = new ObservableCollection<RestaurantModel>(searchData.Restaurants); //await Repository.GetAllSearchResults();// list used for filter results, making copy
            _allRestaurants = new List<RestaurantModel>(searchData.Restaurants.ToList()); // list used for filter aka Master list (does not get modified), making copy
            ResultsList.ItemsSource = searchData.Restaurants; // actual listview content
            
            

        }

        private void ResultsList_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e) {
            try {
                var tb = (TextBlock)e.OriginalSource;
                var dataContext = tb.DataContext;


                restaurant = (RestaurantModel)dataContext;
                //Navigate to restaurant landing page
                Frame.Navigate(typeof(LandingPage), restaurant);
            }
            catch {

            }
        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            SearchData searchData = (SearchData)Application.Current.Resources["searchData"];
            searchData.Restaurants.Clear(); // clear search query.
            this.Frame.Navigate(typeof(MainPage));

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

        /// <summary>
        /// filter method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterTextbox_TextChanged(object sender, TextChangedEventArgs e) {
            
            if (filterTextbox.Text == null) {
                filterTextbox.Text = "";
            }
            var lowerCaseFilter = filterTextbox.Text.ToLowerInvariant().Trim();
            //Uses Linq to filter data (kinda like SQL querying)
            var result = _allRestaurants.Where(
                d => d.Name.ToLowerInvariant()
                        .Contains(lowerCaseFilter)).ToList();

            var toRemove = RestaurantList.Except(result).ToList();
            foreach (var x in toRemove) {
                RestaurantList.Remove(x);
            }
            //Add back in the correct order.
            var resultcount = result.Count;
            for (int i = 0; i < resultcount; i++) {
                var resultItem = result[i];
                if (i + 1 > RestaurantList.Count || !RestaurantList[i].Equals(resultItem)) {
                    RestaurantList.Insert(i, resultItem);
                }
            }
            ResultsList.ItemsSource = RestaurantList;
            
        }
    }
}

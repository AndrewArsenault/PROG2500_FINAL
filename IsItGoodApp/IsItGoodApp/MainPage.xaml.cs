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
using Yelp.Api;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IsItGoodApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        SearchData searchData = (SearchData)Application.Current.Resources["searchData"];

        public MainPage()
        {
            this.InitializeComponent();
        }

        //search through restaurants
        private async void  btnSearch_Click(object sender, RoutedEventArgs e)
        {

            //if the text is empty, don't let them search
            if (tbLocation.Text == "" || tbSearch.Text == "")
            {

                    ContentDialog badInputDialog = new ContentDialog()
                    {
                        Title = "Bad search input",
                        Content = "Please check search values",
                        CloseButtonText = "Ok"
                    };

                    await badInputDialog.ShowAsync();
               

                return;
            }

            //get search data
            searchData.searchKeyWord = tbSearch.Text;
            searchData.searchLocation = tbLocation.Text;

            //set up yelp api client
            var client = new Yelp.Api.Client("uhYZFxMUHsPL7QO5AWYmIVGnrO1n_neqgTDJLZwQyFT2oHCzABvq5_BuXljPrjfS_DO3gkVoRwW2msSEj01JnP7gZAh1BEsDj2wz8zUO8m-Ka9eKrXRypgGzHYS6WnYx");

            //set up the request
            var request = new Yelp.Api.Models.SearchRequest();
            request.Term = searchData.searchKeyWord;
            request.Location = searchData.searchLocation;

            //send request async and get results
            var results = await client.SearchBusinessesAllAsync(request);

            int resultCount = results.Businesses.Count;
            
            //for each result, make a restaurant model and add it to search data
            for(int i =0; i < resultCount; i++)
            {
                RestaurantModel rm = new RestaurantModel(results.Businesses[i].Name,
                    results.Businesses[i].Phone, results.Businesses[i].Rating, results.Businesses[i].Categories,
                    results.Businesses[i].Url, results.Businesses[i].Location.Address1, results.Businesses[i].Location.Country,
                    results.Businesses[i].Location.State, results.Businesses[i].Location.City, results.Businesses[i].Location.ZipCode,
                    results.Businesses[i].ImageUrl, results.Businesses[i].IsClosed);

                searchData.Restaurants.Add(rm);
        
            }

            //Navigate to search results page

            this.Frame.Navigate(typeof(SearchResults));


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

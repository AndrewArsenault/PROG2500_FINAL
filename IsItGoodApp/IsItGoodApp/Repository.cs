using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace IsItGoodApp
{
    class Repository
    {
        

        public static async Task<ObservableCollection<RestaurantModel>> GetAllSearchResults()
        {
            SearchData searchData = (SearchData)Application.Current.Resources["searchData"];

            return searchData.Restaurants;

        }

        }
}

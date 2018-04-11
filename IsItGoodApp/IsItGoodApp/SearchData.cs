using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IsItGoodApp
{
    class SearchData{
       
        public string searchKeyWold;
        public string searchLocation;
        public ObservableCollection<RestaurantModel> Restaurants { get; set; }
        public SearchData() {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsItGoodApp {
    public class RestaurantModel {
        public String Name { get; set; }
        public String Phone { get; set; }
        public int Rating { get; set; }
        public String[] Categories { get; set; }
        public String URL { get; set; }
        public String Address { get; set; }
        public String Country { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public String ZipCode { get; set; }
        public String ImageUrl { get; set; }
        public bool IsClosed { get; set; }

        public RestaurantModel() {

        }

        public RestaurantModel(String Name, String Phone, int Rating, String[] Categories,
            String URL, String Address, String Country, String State, String City, String ZipCode, String ImageUrl, bool IsClosed ){
            this.Name = Name;
            this.Phone = Phone;
            this.Rating = Rating;
            this.Categories = Categories;
            this.URL = URL;
            this.Address = Address;
            this.Country = Country;
            this.State = State;
            this.City = City;
            this.ZipCode = ZipCode;
            this.ImageUrl = ImageUrl;
            this.IsClosed = IsClosed;
        }
    }
}

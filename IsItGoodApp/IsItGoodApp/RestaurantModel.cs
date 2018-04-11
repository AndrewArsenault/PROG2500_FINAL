using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsItGoodApp {
    class RestaurantModel {
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsItGoodApp
{
    public class LandingPageData
    {
        public RestaurantModel restaurant;

        public string openString;
        public string ratingString;

        public LandingPageData()
        {
        }

        public void LoadRestaurant()
        {
            if (restaurant == null)
            {
                restaurant = new RestaurantModel(
                "Gary Danko",
                "+14152520800",
                4.5F,
                new Yelp.Api.Models.Category[] { },
                "https://www.yelp.com/biz/gary-danko-san-francisco",
                "800 N Point St", "US", "CA", "San Francisco", "94109",
                "https://s3-media4.fl.yelpcdn.com/bphoto/--8oiPVp0AsjoWHqaY1rDQ/o.jpg",
                false);
            }

            ratingString = restaurant.Rating.ToString();

            if (restaurant.IsClosed)
            {
                openString = "Closed Now";
            }
            else
            {
                openString = "Open Now";
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsItGoodApp
{
    /// <summary>
    /// Data for use on landing page
    /// </summary>
    public class LandingPageData
    {
        /// <summary>
        /// The selected restaurant to display on landing page
        /// </summary>
        public RestaurantModel restaurant;

        /// <summary>
        /// String representing if restaurant is open or not
        /// </summary>
        public string openString;
        /// <summary>
        /// String representing user rating of restaurant
        /// </summary>
        public string ratingString;

        /// <summary>
        /// Default constructor
        /// </summary>
        public LandingPageData()
        {
        }

        /// <summary>
        /// Loads restaurant details. If restaurant is null, make a default restaurant.
        /// Converts rating from float to string.
        /// Updates openString
        /// </summary>
        public void LoadRestaurantDetails()
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

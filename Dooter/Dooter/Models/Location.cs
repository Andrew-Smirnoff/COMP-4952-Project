using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dooter.Models
{
    public class Location
    {
        public int LocationID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Rating is required")]
        [Range (1.0, 5.0, ErrorMessage = "Ratings are 1 to 5 stars")]
        public double? Rating { get; set; }

        //[Required(ErrorMessage = "latitude is required")]
        public double? Latitude { get; set; }

        //[Required(ErrorMessage = "longitude is required")]
        public double? Longitude { get; set; }
    }
}

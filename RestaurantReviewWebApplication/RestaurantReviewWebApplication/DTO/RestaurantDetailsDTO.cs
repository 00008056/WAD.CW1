using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviewWebApplication.DTO
{
    public class RestaurantDetailsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IFormFile Image { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Website { get; set; }
    }
}

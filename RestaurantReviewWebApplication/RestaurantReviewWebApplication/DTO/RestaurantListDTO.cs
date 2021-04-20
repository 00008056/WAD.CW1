using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviewWebApplication.DTO
{
    public class RestaurantListDTO
    {
       
        public string Name { get; set; }

        public IFormFile Image { get; set; }
    }
}

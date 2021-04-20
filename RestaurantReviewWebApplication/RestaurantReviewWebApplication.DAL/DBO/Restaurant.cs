
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviewWebApplication.DAL.DBO
{
    public class Restaurant
    {
        //Model class for Restaurant object with corresponding fields and reasonable validation
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        public string Image { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public string Website { get; set; }

        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; }
    }

    
public enum Category
{
    Cafe,
    FastFood,
    CasualDining,
    FineDining
}
}

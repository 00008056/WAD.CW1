using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviewWebApplication.DAL.DBO
{
    public class Author
    {
        //Model class for Author object with corresponding fields and reasonable validation
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string BriefInfo { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}

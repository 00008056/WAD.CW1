using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace RestaurantReviewWebApplication.Models
{
    public class Review
    {
        //Model class for Review object with corresponding fields and reasonable validation
        public int Id { get; set; }

        [Range(0, 5, ErrorMessage = "Please select number between 1 and 5")]
        public int Rating { get; set; }

        [Required]
        public string Content { get; set; }

        public int? AuthorId { get; set; }

        [Required]
        public bool WouldRecommend { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public virtual Author Author { get; set; }
    }
}

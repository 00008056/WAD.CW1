using Microsoft.EntityFrameworkCore;
using RestaurantReviewWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviewWebApplication.DAL
{
    public class RestaurantReviewWebApplicationDbContext:DbContext
    {
        public RestaurantReviewWebApplicationDbContext(DbContextOptions<RestaurantReviewWebApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
    }
}

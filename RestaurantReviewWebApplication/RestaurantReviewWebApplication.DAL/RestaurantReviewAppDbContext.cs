﻿using Microsoft.EntityFrameworkCore;
using RestaurantReviewWebApplication.DAL.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviewWebApplication.DAL
{
    public class RestaurantReviewAppDbContext: DbContext
    {
        public RestaurantReviewAppDbContext(DbContextOptions<RestaurantReviewAppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

    }
}

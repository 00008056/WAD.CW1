using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantReviewWebApplication.DAL.Repos
{
    public abstract class BaseRepo
    {
        protected readonly RestaurantReviewAppDbContext _context;

        protected BaseRepo(RestaurantReviewAppDbContext context)
        {
            _context = context;
        }
    }
}

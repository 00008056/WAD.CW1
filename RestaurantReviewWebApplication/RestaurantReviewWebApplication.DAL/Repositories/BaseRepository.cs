using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantReviewWebApplication.DAL.Repositories
{
    public class BaseRepository
    {
        //protected
        protected readonly RestaurantReviewWebApplicationDbContext _context;

        protected BaseRepository(RestaurantReviewWebApplicationDbContext context)
        {
            _context = context;
        }
    }
}

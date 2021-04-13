using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewWebApplication.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        bool Exists(int id);
    }
}

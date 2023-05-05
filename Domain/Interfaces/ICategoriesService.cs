using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<ProductCategory>> GetAll();
        Task<ProductCategory> GetById(int id);
        Task Create(ProductCategory model);
        Task Update(ProductCategory model);
        Task<ProductCategory> Delete(int id);
    }
}

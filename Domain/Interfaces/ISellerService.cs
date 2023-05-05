using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISellerService
    {
        Task<List<Seller>> GetAll();
        Task<Seller> GetById(int id);
        Task Create(Seller model);
        Task Update(Seller model);
        Task<Seller> Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<Buyer>> GetAll();
        Task<Buyer> GetById(int id);
        Task Create(Buyer model);
        Task Update(Buyer model);
        Task Delete(int id);
    }
}

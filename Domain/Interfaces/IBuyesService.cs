using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBuyesService
    {
        Task<List<Buy>> GetAll();
        Task<Buy> GetById(int id);
        Task Create(Buy model);
        Task Update(Buy model);
        Task<Buy> Delete(int id);
    }
}

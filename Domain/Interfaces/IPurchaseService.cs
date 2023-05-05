using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPurchaseService
    {
        Task<List<PurchaseContent>> GetAll();
        Task<PurchaseContent> GetById(int id);
        Task Create(PurchaseContent model);
        Task Update(PurchaseContent model);
        Task<PurchaseContent> Delete(int id);
    }
}

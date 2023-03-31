using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<Buyer>, IUserRepository
    {
        public UserRepository(EthernetShopContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public Task Create(Domain.Models.Buyer entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Domain.Models.Buyer entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Models.Buyer>> FindByCondition(Expression<Func<Domain.Models.Buyer, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task Update(Domain.Models.Buyer entity)
        {
            throw new NotImplementedException();
        }

        Task<List<Domain.Models.Buyer>> IRepositoryBase<Domain.Models.Buyer>.FindAll()
        {
            throw new NotImplementedException();
        }
    }
}

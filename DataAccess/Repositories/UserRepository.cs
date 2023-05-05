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
    }
}

using Domain.Interfaces;
using DataAccess;
using Domain.Models;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private EthernetShopContext _repoContext;

        public RepositoryWrapper(EthernetShopContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IUserRepository User => throw new NotImplementedException();

        public void Save()
        {
            _repoContext.SaveChanges();
        }

        Task IRepositoryWrapper.Save()
        {
            throw new NotImplementedException();
        }
    }
}

using Domain;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Buyer>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }
        public async Task<Buyer> GetById(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.BuyerId == id);
            return user.First();
        }
        public async Task Create(Buyer model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }    

            if(string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentException(nameof(model.Name));
            }

            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Buyer model)
        {
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task<Buyer> Delete(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.BuyerId == id);
            _repositoryWrapper.User.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}

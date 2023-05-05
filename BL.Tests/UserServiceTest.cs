using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Services;
using Moq;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BL.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepMoq;

        public UserServiceTest()
        {
            var repWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepMoq = new Mock<IUserRepository>();

            repWrapperMoq.Setup(p=>p.User).Returns(userRepMoq.Object);
            service = new UserService(repWrapperMoq.Object);
        }

        [Fact]
        public async Task CreateAsync_Nulluser_ShouldThrowNullArgExcpt()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepMoq.Verify(p=>p.Create(It.IsAny<Buyer>()),Times.Never());
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] { new Buyer() { Surname = "",Name = "",Patronymic = "",Passport = int.MaxValue,HomeAddress = "",PhoneNumber = int.MaxValue } },
                new object[] { new Buyer() { Surname = "Test",Name = "",Patronymic = "",Passport = int.MaxValue,HomeAddress = "",PhoneNumber = int.MaxValue } },
                new object[] { new Buyer() { Surname = "Test",Name = "Test",Patronymic = "",Passport = int.MaxValue,HomeAddress = "",PhoneNumber = int.MaxValue } },
            };
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser()
        {
            var newuser = new Buyer()
            {
                Surname = "",
                Name = "",
                Patronymic = "",
                Passport = int.MaxValue,
                HomeAddress = "",
                PhoneNumber = int.MaxValue,

            };

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newuser));
            Assert.IsType<ArgumentException>(ex);
        }
    }
}

using System;
using AutoMapper;
using AcmeCorp.Application.Services;
using AcmeCorp.Application.ViewModels;
using AcmeCorp.Domain.Interfaces;
using Moq;
using Xunit;

namespace AcmeCorp.Application.UnitTests.Services
{
    public class CustomerAppServiceTests
    {
        [Fact]
        public void GetById()
        {
            // Arrange
            var customer = new Domain.Models.Customer(new Guid(), "Alan", "alab@test.com", new DateTime());

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.GetById(customer.Id))
                .Returns(customer);
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<CustomerViewModel>(customer)).Returns(new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                BirthDate = customer.BirthDate,
            });

            // Act
            var sut = new CustomerAppService(mapperMock.Object, customerRepositoryMock.Object, null, null);
            var result = sut.GetById(customer.Id);

            // Assert
            Assert.Equal(result.Id, customer.Id);
            Assert.Equal(result.Name, customer.Name);
            Assert.Equal(result.Email, customer.Email);
            Assert.Equal(result.BirthDate, customer.BirthDate);
        }
    }
}

using AutoFixture;
using DemoMVC.DataAccess.Repository.IRepository;
using DemoMVC.Models;
using DemoMVC.Web.Areas.Admin.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Moq;
using System.Security.Cryptography.X509Certificates;

namespace DemoMVC.Test.Controllers
{
    public class CategoryControllerTests
    {
        public readonly IFixture _fixture;
        public readonly Mock<IUnitOfWork> _unitOfWork;
        public readonly CategoryController _controller;
        public CategoryControllerTests()
        {
            _fixture= new Fixture();
            _unitOfWork = _fixture.Freeze<Mock<IUnitOfWork>>();
            _controller = new CategoryController(_unitOfWork.Object);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithCategoriesList()
        {
            //Arrange

            var categoryMock = _fixture.Create<List<Category>>();
            _unitOfWork.Setup(s => s.Category.GetAll("Id,Name"))
                .Returns(categoryMock);

            var categoryController = new CategoryController(_unitOfWork.Object);

            // Act
            var result = categoryController.Index();

            // Assert
            result.Should().NotBeNull();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Category>>(
                viewResult.ViewData.Model);
        }
    }
}
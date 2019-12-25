﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProjectName.Api.Application.Commands;
using ProjectName.Api.Application.Queries;
using ProjectName.Api.Controllers;
using ProjectName.Api.ViewModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ProjectName.UnitTest.Api
{
    public class BlogWebApiTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IBlogQueries> _blogQueriesMock;
        private readonly Mock<ILogger<BlogController>> _loggerMock;

        public BlogWebApiTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _blogQueriesMock = new Mock<IBlogQueries>();
            _loggerMock = new Mock<ILogger<BlogController>>();
        }

        [Fact]
        public async Task Get_Blog_with_Id_NotFound()
        {
            //Arrange
            int IdHas = 123;
            int IdNotFound = 1;
            var blog = new BlogViewModel() { Id = IdHas, Title = "Test", Description = "Test" };
            _blogQueriesMock.Setup(x => x.GetAsync(IdHas)).ReturnsAsync(blog);

            //Act
            var blogController = new BlogController(_loggerMock.Object, _mediatorMock.Object, _blogQueriesMock.Object);
            var actionResult = await blogController.Get(IdNotFound) as NotFoundResult;

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Get_Blog_with_Id_Success()
        {
            //Arrange
            int IdHas = 123;
            var blog = new BlogViewModel() { Id = IdHas, Title = "Test", Description = "Test" };
            _blogQueriesMock.Setup(x => x.GetAsync(IdHas)).ReturnsAsync(blog);

            //Act
            var blogController = new BlogController(_loggerMock.Object, _mediatorMock.Object, _blogQueriesMock.Object);
            var actionResult = await blogController.Get(IdHas) as OkObjectResult;

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Create_Blog_Success()
        {
            //Arrange
            var resultExpect = new BlogViewModel() { Id = 1, Title = "New Blog", Description = "Blog description" };
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateBlogCommand>(), default(CancellationToken)))
                .Returns(Task.FromResult(resultExpect));

            //Act
            var blogController = new BlogController(_loggerMock.Object, _mediatorMock.Object, _blogQueriesMock.Object);
            var command = new CreateBlogCommand() { Title = "New Blog 1", Description = "Blog description" };
            var actionResult = await blogController.PostAsync(command) as OkObjectResult;

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Vaildate_Create_Blog_Command_Input_Title_Empty()
        {
            //Arrange
            var _loggerMock = new Mock<ILogger<CreateBlogCommandValidator>>();
            var validator = new CreateBlogCommandValidator(_loggerMock.Object);
            var command = new CreateBlogCommand() { Title = "", Description = "Blog description" };

            //Act
            var validationResult = await validator.ValidateAsync(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public async Task Vaildate_Create_Blog_Command_Input_Description_Empty()
        {
            //Arrange
            var _loggerMock = new Mock<ILogger<CreateBlogCommandValidator>>();
            var validator = new CreateBlogCommandValidator(_loggerMock.Object);
            var command = new CreateBlogCommand() { Title = "New Blog", Description = "" };

            //Act
            var validationResult = await validator.ValidateAsync(command);

            //Assert
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public async Task Vaildate_Create_Blog_Command_Input_OK()
        {
            //Arrange
            var _loggerMock = new Mock<ILogger<CreateBlogCommandValidator>>();
            var validator = new CreateBlogCommandValidator(_loggerMock.Object);
            var command = new CreateBlogCommand() { Title = "New Blog", Description = "Blog description" };

            //Act
            var validationResult = await validator.ValidateAsync(command);

            //Assert
            Assert.True(validationResult.IsValid);
        }
    }
}
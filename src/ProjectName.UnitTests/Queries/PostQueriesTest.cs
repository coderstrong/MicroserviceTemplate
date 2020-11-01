using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectName.Api.Application.Queries;
using ProjectName.Api.Model;
using ProjectName.Domain.Entities;
using ProjectName.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProjectName.UnitTest.Queries
{
    public class PostQueriesTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<BlogContext> _blogContextMock;

        public PostQueriesTest()
        {
            _mapperMock = new Mock<IMapper>();
            _blogContextMock = new Mock<BlogContext>();
        }

        [Fact]
        public async Task GetAsync_List()
        {
            //Arrange
            var data = new List<Post>
            {
                new Post {Author = "BBB", Content ="sadfa", Id = Guid.NewGuid() , Status =new PostStatus(1,"Test"), Title = ""},
                new Post {Author = "BBB", Content ="sadfa", Id = Guid.NewGuid() , Status =new PostStatus(1,"Test"), Title = ""},
                new Post {Author = "BBB", Content ="sadfa", Id = Guid.NewGuid() , Status =new PostStatus(1,"Test"), Title = ""},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Post>>();
            mockSet.As<IQueryable<Post>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Post>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Post>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Post>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            _blogContextMock.Setup(x => x.Posts).Returns(mockSet.Object);

            //Act
            var postQueries = new PostQueries(_blogContextMock.Object, _mapperMock.Object);
            var actionResult = await postQueries.GetAsync();

            //Assert
            Assert.True(actionResult is List<PostResponseModel>);
        }

        [Fact]
        public async Task GetAsyncById_Found()
        {
            //Arrange
            Guid Id = Guid.NewGuid();
            var mockSet = new Mock<DbSet<Post>>();
            _blogContextMock.Setup(x => x.Posts).Returns(mockSet.Object);

            //Act
            var postQueries = new PostQueries(_blogContextMock.Object, _mapperMock.Object);
            var actionResult = await postQueries.GetAsync(Id);

            //Assert
            Assert.True(actionResult is PostResponseModel);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectName.API.Model;
using ProjectName.Domain.Common;
using ProjectName.Domain.Entities;
using ProjectName.Infrastructure.Database;

namespace ProjectName.API.Application.Commands
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogResponseModel>
    {
        private readonly IRepositoryGeneric<BlogContext, Blog> _blog;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IRepositoryGeneric<BlogContext, Blog> blog, IMapper mapper)
        {
            _blog = blog;
            _mapper = mapper;
        }

        public async Task<BlogResponseModel> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog blog = new Blog()
            {
                Title = request.Title,
                Description = request.Description
            };

            blog = _blog.Insert(blog);

            await _blog.UnitOfWork.SaveEntitiesAsync();

            return _mapper.Map<BlogResponseModel>(blog);
        }
    }
}

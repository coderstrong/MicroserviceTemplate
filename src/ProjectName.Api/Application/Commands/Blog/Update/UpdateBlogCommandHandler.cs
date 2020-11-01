using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectName.Domain.Common;
using ProjectName.Domain.Entities;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Application.Commands
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, bool>
    {
        private readonly IRepositoryGeneric<BlogContext, Blog> _blog;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IRepositoryGeneric<BlogContext, Blog> blog, IMapper mapper)
        {
            _blog = blog;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog blog = new Blog()
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description
            };

            _blog.Update(blog);

            return await _blog.UnitOfWork.SaveEntitiesAsync();
        }
    }
}

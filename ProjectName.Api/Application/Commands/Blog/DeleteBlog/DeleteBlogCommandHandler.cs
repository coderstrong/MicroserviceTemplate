using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectName.Domain.Common;
using ProjectName.Domain.Entities;
using ProjectName.Infrastructure.Database;

namespace ProjectName.Api.Application.Commands
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, bool>
    {
        private readonly IRepositoryGeneric<BlogContext, Blog> _blog;
        private readonly IMapper _mapper;

        public DeleteBlogCommandHandler(IRepositoryGeneric<BlogContext, Blog> blog, IMapper mapper)
        {
            _blog = blog;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            _blog.Delete(request.Id);

            return await _blog.UnitOfWork.SaveEntitiesAsync();
        }
    }
}

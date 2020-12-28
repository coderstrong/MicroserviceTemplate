using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectName.ModuleName.Domain.Entities;
using ProjectName.ModuleName.Domain.SeedWork;
using ProjectName.ModuleName.Infrastructure.Database;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Blog>
    {
        private readonly IRepositoryGeneric<ProjectNameModuleNameContext, Blog> _blog;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IRepositoryGeneric<ProjectNameModuleNameContext, Blog> blog, IMapper mapper)
        {
            _blog = blog;
            _mapper = mapper;
        }

        public async Task<Blog> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
        {
            Blog blog = _mapper.Map<Blog>(command);

            blog = _blog.Insert(blog);

            await _blog.UnitOfWork.SaveEntitiesAsync();

            return blog;
        }
    }
}
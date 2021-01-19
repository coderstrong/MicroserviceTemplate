using AutoMapper;
using MediatR;
using ProjectName.ModuleName.Domain.Entities;
using ProjectName.ModuleName.Domain.SeedWork;
using ProjectName.ModuleName.Infrastructure.Database;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectName.ModuleName.Application.Commands
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Blog>
    {
        private readonly IRepositoryGeneric<ProjectNameModuleNameContext, Blog> _blog;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IRepositoryGeneric<ProjectNameModuleNameContext, Blog> blog, IMapper mapper)
        {
            _blog = blog;
            _mapper = mapper;
        }

        public async Task<Blog> Handle(UpdateBlogCommand command, CancellationToken cancellationToken)
        {
            Blog blog = _mapper.Map<Blog>(command);

            _blog.Update(blog);

            await _blog.UnitOfWork.SaveEntitiesAsync();

            return blog;
        }
    }
}
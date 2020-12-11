using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectName.ModuleName.Domain.Entities;
using ProjectName.ModuleName.Domain.SeedWork;
using ProjectName.ModuleName.Infrastructure.Database;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class UpdatePostTagCommandHandler : IRequestHandler<UpdatePostTagCommand, PostTag>
    {
        private readonly IRepositoryGeneric<ProjectNameModuleNameContext, PostTag> _posttag;
        private readonly IMapper _mapper;

        public UpdatePostTagCommandHandler(IRepositoryGeneric<ProjectNameModuleNameContext, PostTag> posttag, IMapper mapper)
        {
            _posttag = posttag;
            _mapper = mapper;
        }

        public async Task<PostTag> Handle(UpdatePostTagCommand command, CancellationToken cancellationToken)
        {
            PostTag posttag = _mapper.Map<PostTag>(command);

            _posttag.Update(posttag);

            await _posttag.UnitOfWork.SaveEntitiesAsync();

            return posttag;
        }
    }
}

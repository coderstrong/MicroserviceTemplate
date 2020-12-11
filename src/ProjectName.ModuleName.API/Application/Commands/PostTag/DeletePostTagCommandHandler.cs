using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ProjectName.ModuleName.Domain.Entities;
using ProjectName.ModuleName.Domain.SeedWork;
using ProjectName.ModuleName.Infrastructure.Database;

namespace ProjectName.ModuleName.API.Application.Commands
{
    public class DeletePostTagCommandHandler : IRequestHandler<DeletePostTagCommand, PostTag>
    {
        private readonly IRepositoryGeneric<ProjectNameModuleNameContext, PostTag> _posttag;
        private readonly IMapper _mapper;

        public DeletePostTagCommandHandler(IRepositoryGeneric<ProjectNameModuleNameContext, PostTag> posttag, IMapper mapper)
        {
            _posttag = posttag;
            _mapper = mapper;
        }

        public async Task<PostTag> Handle(DeletePostTagCommand command, CancellationToken cancellationToken)
        {
            PostTag posttag = _mapper.Map<PostTag>(command);

            posttag = _posttag.Insert(posttag);

            await _posttag.UnitOfWork.SaveEntitiesAsync();

            return posttag;
        }
    }
}

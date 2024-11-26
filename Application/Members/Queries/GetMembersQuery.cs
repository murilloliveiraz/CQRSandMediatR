using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Members.Queries
{
    public class GetMembersQuery: IRequest<IEnumerable<Member>>
    {
        public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
        {
            private readonly IMemberDapperRepository _repository;
            public GetMembersQueryHandler(IMemberDapperRepository repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
            {
                var members = await _repository.GetAll();
                return members;
            }
        }
    }
}

using Application.Members.Commands.Notifications;
using Domain.Abstractions;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Members.Commands
{
    public class CreateMemberCommand: MemberCommandBase
    {
        public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMediator _mediator;

            public CreateMemberCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
            {
                _unitOfWork = unitOfWork;
                _mediator = mediator;
            }

            public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
            {
                var newMember = new Member(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive);
                await _unitOfWork.MemberRepository.AddMember(newMember);
                await _unitOfWork.CommitAsync();
                await _mediator.Publish(new MemberCreatedNotification(newMember), cancellationToken);
                return newMember;
            }
        }
    }
}

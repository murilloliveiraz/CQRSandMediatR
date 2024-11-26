using Domain.Entities;
using MediatR;

namespace Application.Members.Commands.Notifications
{
    public class MemberCreatedNotification : INotification
    {
        public Member Member { get; set; }

        public MemberCreatedNotification(Member member) 
        {
            Member = member;
        }
    }
}

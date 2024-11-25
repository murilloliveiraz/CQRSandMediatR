using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member> GetMemberById(int memberId);
        Task<Member> AddMember(Member member);
        void UpdateMember(Member member);
        Task<Member> DeleteMember(int memberId);
    }
}

using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IMemberDapperRepository
    {
        Task<IEnumerable<Member>> GetAll();
        Task<Member> GetMemberById(int memberId);
    }
}

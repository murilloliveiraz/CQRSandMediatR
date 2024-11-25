using Domain.Abstractions;
using Domain.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        protected readonly AppDbContext db;

        public MemberRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<Member> AddMember(Member member)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));

            await db.Members.AddAsync(member); 
            return member;
        }

        public async Task<Member> DeleteMember(int memberId)
        {
            var member = await GetMemberById(memberId);
            if (member is null)
                throw new InvalidOperationException(nameof(member));
            db.Members.Remove(member);
            return member;
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            var memberList = await db.Members.ToListAsync();
            return memberList ?? Enumerable.Empty<Member>();
        }

        public async Task<Member> GetMemberById(int memberId)
        {
            var member = await db.Members.FindAsync(memberId);
            if (member is null)
                throw new InvalidOperationException("Member not found");
            return member;

        }

        public void UpdateMember(Member member)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));

            db.Members.Update(member);
        }
    }
}

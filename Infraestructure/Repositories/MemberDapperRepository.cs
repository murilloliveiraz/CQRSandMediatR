using Dapper;
using Domain.Abstractions;
using Domain.Entities;
using System.Data;

namespace Infraestructure.Repositories
{
    public class MemberDapperRepository : IMemberDapperRepository
    {
        private readonly IDbConnection _dbConnection;

        public MemberDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            string query = "SELECT * FROM \"Members\"";
            return await _dbConnection.QueryAsync<Member>(query);
        }

        public async Task<Member> GetMemberById(int memberId)
        {
            string query = "SELECT * FROM \"Members\" WHERE \"Id\" = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Member>(query, new { Id = memberId });
        }

    }
}

using Dapper;
using Microsoft.Extensions.Configuration;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Repositories;
using Pharmacy.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.DapperRepositories
{
    public class DapperCompanyRepository : Repository<Company>, ICompanyRepository
    {
        private IDbConnection db;

        public DapperCompanyRepository(PharmacyDbContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public override async Task Add(Company entity)
        {
            string sql = "INSERT INTO Companies (CompanyName) VALUES(@CompanyName)";
            await db.ExecuteAsync(sql, entity);
        }


        public override async Task Delete(Company entity)
        {
            string sql = "DELETE FROM Companies WHERE CompanyId = @id";
            await db.ExecuteAsync(sql, new { id = entity.CompanyId });
            
        }

        public override async Task<List<Company>> GetAll()
        {
            string sql = "SELECT * FROM Companies";
            var result = await db.QueryAsync<Company>(sql).ConfigureAwait(false);
            return result.ToList();
        }

        public async Task<Company> GetByCompanyId(int id)
        {

            string sql = "SELECT * FROM Companies WHERE CompanyId = @CompanyId";
            var result = await db.QueryFirstOrDefaultAsync<Company>(sql, new { CompanyId = id }).ConfigureAwait(false);
            return result;
        }

        public override async Task Update(Company entity)
        {
            string sql = "UPDATE Companies Set CompanyName = @CompanyName WHERE CompanyId=@CompanyId";
            await db.ExecuteAsync(sql, entity);


        }

    }
}

using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Repositories;
using Pharmacy.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repositories.EFRepositories
{
    public class EFCompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly PharmacyDbContext _dbContext;
        DbSet<Company> _dbSet;

        public EFCompanyRepository(PharmacyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Company>();
        }

        public Task<Company> GetByCompanyId(int id)
        {
            return _dbSet.Where(c => c.CompanyId == id).FirstOrDefaultAsync();
        }
    }
}

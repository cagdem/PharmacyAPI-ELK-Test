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
    public class EFMedicineRepository : Repository<Medicine>, IMedicineRepository
    {
        private readonly PharmacyDbContext _dbContext;
        DbSet<Medicine> _dbSet;

        public EFMedicineRepository(PharmacyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Medicine>();
        }

        public Task<Medicine> GetByMedicineId(int id)
        {
            return _dbSet.Include(a => a.Company).Where(m => m.MedicineId == id).FirstOrDefaultAsync();
        }

        public Task<List<Medicine>> GetWithCompany(Expression<Func<Medicine, bool>> filter)
        {
            return _dbSet.Include(a => a.Company).Where(filter).ToListAsync();
        }
    }
}

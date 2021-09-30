using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Domain.Repositories
{
    public interface IMedicineRepository : IRepository<Medicine>
    {
        Task<Medicine> GetByMedicineId(int id);
        Task<List<Medicine>> GetWithCompany(Expression<Func<Medicine, bool>> filter);

    }
}

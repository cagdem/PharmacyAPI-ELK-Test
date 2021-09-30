using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Domain.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetByCompanyId(int id); //gibi Entity'e özel işlemler burda tanımlanabilir.
    }
}

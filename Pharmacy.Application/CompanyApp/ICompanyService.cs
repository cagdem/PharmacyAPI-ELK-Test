using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Pharmacy.Application.CompanyApp
{
    public interface ICompanyService
    {
        Task Add(CompanyDto companyDto);
        Task<CompanyDto> GetById(int id);
        Task<List<CompanyDto>> GetAll();
        Task Delete(int id);
        Task Update(CompanyDto companyDto);

    }
}

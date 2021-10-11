using Mapster;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.MedicineApp
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly ICompanyRepository _companyRepository;

        private readonly TypeAdapterSetter _configToMedicineDto = TypeAdapterConfig<(Company, Medicine), MedicineDto>.NewConfig()
                .Map(d => d, s => s.Item2)
                .Map(d => d.CompanyName, s => s.Item1.CompanyName)
;

        private readonly TypeAdapterSetter _configToMedicine = TypeAdapterConfig<(Company, MedicineDto), Medicine>.NewConfig()
                .Map(d => d, s => s.Item2)
                .Map(d => d.CompanyId, s => s.Item1.CompanyId);


        public MedicineService(IMedicineRepository medicineRepository, ICompanyRepository companyRepository)
        {
            _medicineRepository = medicineRepository;
            _companyRepository = companyRepository;
        }

        public async Task Add(MedicineDto medicineDto)
        {
            var current =(await _medicineRepository.Get(x => x.Name.Trim() == medicineDto.Name.Trim())).FirstOrDefault();

            if (current != null) throw new ApplicationException("Ayni adda kayit var");

            var result = _companyRepository.Get(c => c.CompanyName == medicineDto.CompanyName);
            Company company = result.Result.ElementAt(0);
            Medicine data = (company, medicineDto).Adapt<Medicine>(_configToMedicine.Config);

            await _medicineRepository.Add(data);
        }

        public Task Delete(int id)
        {
            var result = _medicineRepository.GetByMedicineId(id);
            return _medicineRepository.Delete(result.Result);
        }

        public async Task<List<MedicineDto>> GetAll()
        {
            List<MedicineDto> data = new List<MedicineDto>();
            var result = await _medicineRepository.GetWithCompany(a => true);
            result = result.OrderBy(x => x.MedicineId).ToList();
            foreach (var item in result)
            {
                data.Add((item.Company, item).Adapt<MedicineDto>(_configToMedicineDto.Config));
            }

            return data;
        }

        public async Task<MedicineDto> GetById(int id)
        {
            var result = await _medicineRepository.GetByMedicineId(id);

            var deneme = (result.Company, result).Adapt<MedicineDto>(_configToMedicineDto.Config);
            return deneme;

        }

        public Task Update(MedicineDto medicineDto)
        {
            var result = _companyRepository.Get(c => c.CompanyName == medicineDto.CompanyName);
            Company company = result.Result.ElementAt(0);
            Medicine data = (company, medicineDto).Adapt<Medicine>(_configToMedicine.Config);

            return _medicineRepository.Update(data);
        }
    }
}

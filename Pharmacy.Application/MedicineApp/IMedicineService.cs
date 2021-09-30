using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.MedicineApp
{
    public interface IMedicineService
    {
        Task Add(MedicineDto medicineDto);
        Task<MedicineDto> GetById(int id);
        Task<List<MedicineDto>> GetAll();
        Task Delete(int id);
        Task Update(MedicineDto medicineDto);
    }
}

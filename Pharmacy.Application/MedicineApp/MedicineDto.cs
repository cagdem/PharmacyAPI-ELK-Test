using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.MedicineApp
{
    public class MedicineDto
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Details { get; set; }

    }
}

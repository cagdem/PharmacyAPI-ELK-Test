using Pharmacy.Domain.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.MedicineApp
{
    public class MedicineDto
    {
        [Key]
        public int MedicineId { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Maximum 15 karakter olmalıdır.")] 
        public string Name { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [Range(1, 50)]
        public int UnitsInStock { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        [ExpirationdateValidation] 
        public DateTime ExpirationDate { get; set; }
        public string Details { get; set; }

    }
}

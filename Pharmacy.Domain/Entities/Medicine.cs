using Pharmacy.Domain.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Domain.Entities
{
    public class Medicine 
    {
        [Key]
        public int MedicineId { get; set; }
        [Required]
        [StringLength(15, ErrorMessage ="Maximum 15 karakter olmalıdır.")] // Ilaç isimleri çok uzun olmadığı için sınırlama getirdim.
        public string Name { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        [Range(1,50)] // Tek seferde maksimum 50 ilacın stoklanmasına izin veriliyor.
        public int UnitsInStock { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        [ExpirationdateValidation] // Son kullanma tarihi geçmiş mi diye kontrol ediliyor.
        public DateTime ExpirationDate { get; set; }
        public string Details { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

    }
}

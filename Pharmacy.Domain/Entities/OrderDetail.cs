using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int MedicineId { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }

        public Order Order { get; set; }

    }
}

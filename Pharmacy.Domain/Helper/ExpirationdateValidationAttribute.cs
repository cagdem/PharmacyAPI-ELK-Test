using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Domain.Helper
{
    public class ExpirationdateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            //Son kullanma tarihi geçmiş ürünlerin eklenmesini istemiyorum.

            DateTime expDate = Convert.ToDateTime(value);
            DateTime now = DateTime.Now;

            if (expDate > now)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CustomerCreditCardModel
    {
        public int CustomerId { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}

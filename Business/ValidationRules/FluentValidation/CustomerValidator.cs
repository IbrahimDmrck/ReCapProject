using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty().WithMessage("Müşteri adı boş bırakılamaz");
            RuleFor(p => p.CompanyName).MinimumLength(3).WithMessage("Müşteri adı en az 3 karakter olabilir");
            
        }
    }
}

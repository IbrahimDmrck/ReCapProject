using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(P => P.CarName).NotEmpty().WithMessage("Araba adı boş bırakılamaz");
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.ModelYear).NotEmpty().WithMessage("Araç modeli belirtilmek zorunda");
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(25).When(p => p.BrandId == 2);

        }

       
    }
}

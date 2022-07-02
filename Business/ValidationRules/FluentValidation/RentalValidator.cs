using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.CarId).NotEmpty().WithMessage("Kiralamak istediğiniz aracı seçin");
            RuleFor(p => p.RentDate).NotEmpty().WithMessage("Kiralama başlangıç tarihini seçin");
            RuleFor(p => p.ReturnDate).NotEmpty().WithMessage("Kiralama bitiş tarihini seçin");
            RuleFor(P => P.CustomerId).NotEmpty().WithMessage("Bu aracı kim kiralıyor ?");
            RuleFor(p => p.ReturnDate).Null().WithMessage("Araç şu anda kullnılıyor kiralanamaz");
        }
    }
}

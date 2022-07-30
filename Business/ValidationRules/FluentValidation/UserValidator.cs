using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Adınızı girin");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyadınızı girin");
            RuleFor(p => p.Email).EmailAddress().NotEmpty().WithMessage("E-posta adresinizi giriniz");
            //RuleFor(p => p.Password).NotEmpty().WithMessage("Şifrenizi giriniz");
            //RuleFor(p => p.Password).MinimumLength(8).WithMessage("Şifre en az 8 karakter olabilir");
            //RuleFor(p => p.Password).MaximumLength(21).WithMessage("Şifre en fazla 21 karakter olabilir");

        }
    }
}

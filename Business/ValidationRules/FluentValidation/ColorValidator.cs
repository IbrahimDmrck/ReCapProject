using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(p => p.ColorName).NotEmpty().WithMessage("Araç rengi belirtilmek zorundadır");
            RuleFor(p => p.ColorName).MinimumLength(3).WithMessage("renk ismi en az 3 karakter olmalı");
        }
    }
}

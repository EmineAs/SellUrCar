using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(x => x.ColorName).NotEmpty().WithMessage("Renk alanını boş geçemezsiniz");
            RuleFor(x => x.ColorName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişini yapın");
            RuleFor(x => x.ColorName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın.");

        }
    }
}

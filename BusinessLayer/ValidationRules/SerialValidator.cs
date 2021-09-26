using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SerialValidator : AbstractValidator<Serial>
    {
        public SerialValidator()
        {
            RuleFor(x => x.SerialName).NotEmpty().WithMessage("Model adını boş geçemezsiniz");
            RuleFor(x => x.SerialName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişini yapın");
            RuleFor(x => x.SerialName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın.");

        }
    }
}

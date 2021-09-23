using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ModellValidator : AbstractValidator<Model>
    {
        public ModellValidator()
        {
            RuleFor(x => x.ModelName).NotEmpty().WithMessage("Model adını boş geçemezsiniz");
            RuleFor(x => x.ModelName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişini yapın");
            RuleFor(x => x.ModelName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın.");

        }
    }
}

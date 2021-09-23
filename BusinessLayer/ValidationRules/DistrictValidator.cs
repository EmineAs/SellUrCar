using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class DistrictValidator : AbstractValidator<District>
    {
        public DistrictValidator()
        {
            RuleFor(x => x.DistrictName).NotEmpty().WithMessage("İlçe adını boş geçemezsiniz");
            RuleFor(x => x.DistrictName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişini yapın");
            RuleFor(x => x.DistrictName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın.");

        }
    }
}

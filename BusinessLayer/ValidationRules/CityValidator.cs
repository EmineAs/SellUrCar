using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(x => x.CityName).NotEmpty().WithMessage("Marka adını boş geçemezsiniz");
            RuleFor(x => x.CityName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.CityName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın.");

        }
    }
}

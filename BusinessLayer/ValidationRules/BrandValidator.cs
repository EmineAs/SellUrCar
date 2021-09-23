using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Marka adını boş geçemezsiniz");
            RuleFor(x => x.BrandName).MaximumLength(10).WithMessage("Lütfen 10 karakterden fazla değer girişi yapmayın.");

        }
    }
}

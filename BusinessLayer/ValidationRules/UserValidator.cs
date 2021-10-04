using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {

        UserRegisterManager userRegisterManager = new UserRegisterManager(new EfUserDal());

        public UserValidator()
        {

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın.");
            RuleFor(x => x.UserSurName).NotEmpty().WithMessage("Kullanıcı soyadını boş geçemezsiniz");
            RuleFor(x => x.UserSurName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.UserSurName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın.");
            RuleFor(x => x.UserMail).EmailAddress().WithMessage("Geçerli bir e posta adresi giriniz");
            RuleFor(x => x.UserPassWord).NotEmpty().WithMessage("Lütfen şifre alanını doldurunuz");
            RuleFor(x => x.UserPassWord).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.UserPhoneNumber).NotEmpty().WithMessage("Telefon numarası kısmını doldurunuz");
            RuleFor(x=>x.UserMail).Must(Isthere).WithMessage("Deneme");
        }
        private bool Isthere(string mail)
        {
            try
            {
                var usermail= userRegisterManager.GetUserMail(mail);
                if (usermail != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    
    }
}

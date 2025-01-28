using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators
{
    public class CustomErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir küçük harf içermelidir."
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir rakam içermelidir."
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
           return new IdentityError
           {
               Description = "Şifre en az bir büyük harf içermelidir."
           };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Description = "Şifre en az bir özel karakter içermelidir."
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Description = $"Şifre en az {length} karakter uzunluğunda olmalıdır."
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Description = $"Bu {email} e-posta adresi zaten kullanılmaktadır."
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Description = $"Bu {userName} kullanıcı adı zaten kullanılmaktadır."
            };
        }
    }
}

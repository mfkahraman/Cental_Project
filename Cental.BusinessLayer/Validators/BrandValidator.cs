using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.BrandName).
                NotEmpty().WithMessage("Marka adı boş geçilemez.")
                .MinimumLength(3).WithMessage("Marka adı en az 3 karakter olmalıdır.");

        }
    }
}

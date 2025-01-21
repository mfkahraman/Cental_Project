using Cental.EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x=> x.ModelName).NotEmpty().WithMessage("Model adı boş geçilemez");
            RuleFor(x=> x.Transmission).NotEmpty().WithMessage("Şanzıman tipi boş geçilemez");
            RuleFor(x=> x.GasType).NotEmpty().WithMessage("Yakıt tipi boş geçilemez");
            RuleFor(x=> x.Price).NotEmpty().WithMessage("Fiyat boş geçilemez");
            RuleFor(x=> x.Year).NotEmpty().WithMessage("Fiyat boş geçilemez");
            RuleFor(x=> x.Kilometer).NotEmpty().WithMessage("Kilometre bilgisi boş geçilemez");
        }
    }
}

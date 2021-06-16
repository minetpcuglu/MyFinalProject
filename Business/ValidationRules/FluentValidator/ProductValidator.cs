using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidator
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Minimum 2 karakter içermelidir");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.UnitPrice).GreaterThan(0);
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(10).When(p=>p.CategoryId==1);  //category ıd 1 olanların baslangıc fiyatı 10 ayarla
            //ürünlerin ismi a ile baslayanlar 
            RuleFor(x => x.ProductName).Must(StartWithA).WithMessage("Ürün isminiz 'A' harfi  ile başlamalıdır");  //must uymalı 
        }

        private bool StartWithA(string arg) //kendi metodumuzu olusturduk ampulden 
        {
            return arg.StartsWith("A");
        }
    }
}

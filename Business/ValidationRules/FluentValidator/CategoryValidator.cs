using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidator
{
   public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Minimum 2 karakter içermelidir");
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Boş geçilemez");
        }
    }
}

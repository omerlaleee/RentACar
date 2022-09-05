using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        // For Integers
        // Not Empty → It can not be 0.
        // Not Null  → It can be 0.

        // For Strings
        // Not Empty → It can not be whitespace.
        // Not Null  → It can be whitespace.
        public BrandValidator()
        {
            RuleFor(c => c.BrandName).NotEmpty();
        }
    }
}

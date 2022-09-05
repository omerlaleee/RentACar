using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            // For Integers
            // Not Empty → It can not be 0.
            // Not Null  → It can be 0.

            // For Strings
            // Not Empty → It can not be whitespace.
            // Not Null  → It can be whitespace.
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ModelYear).NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.Description).NotNull();
        }
    }
}

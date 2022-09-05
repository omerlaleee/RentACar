using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        // For Integers
        // Not Empty → It can not be 0.
        // Not Null  → It can be 0.

        // For Strings
        // Not Empty → It can not be whitespace.
        // Not Null  → It can be whitespace.

        //public int RentalId { get; set; }

        //public int CarId { get; set; }
        //public int CustomerId { get; set; }
        //public DateTime RentDate { get; set; }
        //public DateTime ReturnDate { get; set; }
        //public bool IsRentalCompleted { get; set; }

        public RentalValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.RentDate).NotNull();
            RuleFor(c => c.ReturnDate).NotNull();
            RuleFor(c => c.IsRentalCompleted).NotNull();
        }
    }
}

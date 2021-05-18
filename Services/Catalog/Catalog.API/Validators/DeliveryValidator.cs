using Catalog.API.DTO;
using Catalog.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Validators
{
    public class DeliveryValidator : AbstractValidator<DeliveryDTO>
    {
        public DeliveryValidator()
        {
            RuleFor(p => p.DeliveryTime)
               .NotNull()
               .WithMessage("{PropertyName} should be NOT Null!");
            RuleFor(p => p.DeliveryType)
                .NotEmpty()
                .WithMessage("{PropertyName} should be NOT empty. NEVER!")
                .Length(2,50)
                .WithMessage("Length should be between 2 and 50!");
            RuleFor(p => p.Price)
                .NotEmpty()
                .WithMessage("{PropertyName} should be NOT empty. NEVER!")
                .NotEqual(0)
                .WithMessage("{PropertyName} should be NOT equal to 0!")
                .LessThan(0)
                .WithMessage("{PropertyName} should be MORE than 0!");
        }
    }
}

using Catalog.API.DTO;
using Catalog.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Validators
{
    public class ItemValidator : AbstractValidator<ItemDTO>
    {
        public ItemValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} should be NOT empty. NEVER!")
                .Length(2,50)
                .WithMessage("Length should be betwean 2 and 50!");
            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} should be NOT empty. NEVER!")
                .Length(10, 500)
                .WithMessage("Length should be betwean 10 and 500!");
            RuleFor(p => p.Category)
                .NotEmpty()
                .WithMessage("{PropertyName} should be NOT empty. NEVER!")
                .Length(2, 50)
                .WithMessage("Length should be betwean 2 and 50!");
            RuleFor(p => p.DeliveryId)
                .NotEmpty()
                .WithMessage("{PropertyName} should be NOT empty. NEVER!");
            RuleFor(p => p.ImagePath)
                .NotEmpty()
                .WithMessage("{PropertyName} should be NOT empty. NEVER!")
                .Length(2, 255)
                .WithMessage("Length should be betwean 2 and 255!");
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

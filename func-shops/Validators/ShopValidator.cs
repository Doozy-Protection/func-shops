using FluentValidation;
using func_shops.Models;

namespace func_shops.Validators;

public class ShopValidator : AbstractValidator<Shop>
{
    public ShopValidator()
    {
        RuleFor(store => store).NotNull().WithMessage("Shop must not be null");

        RuleFor(store => store.ShopId).NotNull().NotEmpty().WithMessage("Shop Id is required");
        RuleFor(store => store.Name).NotNull().NotEmpty().WithMessage("Name is required");
        RuleFor(store => store.Email).NotNull().NotEmpty().WithMessage("Email is required");
        RuleFor(store => store.Domain).NotNull().NotEmpty().WithMessage("Domain is required");
        RuleFor(store => store.Timezone).NotNull().NotEmpty().WithMessage("Timezone is required");
        RuleFor(store => store.MoneyFormat).NotNull().NotEmpty().WithMessage("MoneyFormat is required");
    }
}
using Adactin.Insurance.API.DTO;
using FluentValidation;

namespace Adactin.Insurance.API.Validators
{
    public class CalculatePremiumRequestDTOValidator : AbstractValidator<CalculatePremiumRequestDTO>
    {
        public CalculatePremiumRequestDTOValidator()
        {
            RuleFor(d=>d.FullName).NotEmpty();
            RuleFor(d=>d.Age).NotEmpty().GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
            RuleFor(d => d.OccupationId).NotEmpty().GreaterThanOrEqualTo(1).LessThanOrEqualTo(6);
            RuleFor(d => d.DeathSumAssured).NotEmpty().GreaterThanOrEqualTo(1).LessThanOrEqualTo(999999999);
        }
    }
}

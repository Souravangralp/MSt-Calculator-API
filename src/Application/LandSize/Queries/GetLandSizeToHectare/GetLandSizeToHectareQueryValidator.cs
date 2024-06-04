namespace CalculatorAPI.Application.LandSize.Queries.GetLandSizeToHectare;

public class GetLandSizeToHectareQueryValidator : AbstractValidator<GetLandSizeToHectareQuery>
{
    public GetLandSizeToHectareQueryValidator()
    {
        RuleFor(x => x.LandSize)
            .GreaterThan(0)
            .WithMessage("Please provide valid land size.");
    }
}

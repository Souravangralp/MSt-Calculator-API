namespace CalculatorAPI.Application.LoanToValueRatio.Queries.GetLoanToValueRatio;

public class GetLoanToValueRatioQueryValidator : AbstractValidator<GetLoanToValueRatioQuery>
{
    public GetLoanToValueRatioQueryValidator()
    {
        RuleFor(x => x.LoanAmount)
            .GreaterThan(0)
            .WithMessage("LoanAmount should be greater then 0.");

        RuleFor(x => x.SecurityAmount)
            .GreaterThan(0)
            .WithMessage("SecurityAmount should be greater then 0.");

        RuleFor(x => x)
            .Must(x => x.SecurityAmount >= x.LoanAmount)
            .WithMessage("SecurityAmount should be greater than LoanAmount.");
    }
}

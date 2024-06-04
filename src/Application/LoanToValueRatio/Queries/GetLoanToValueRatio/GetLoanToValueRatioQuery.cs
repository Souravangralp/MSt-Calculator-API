using MSt_Calculator_API.Application.Common.Interfaces.CalculatorServices;

namespace CalculatorAPI.Application.LoanToValueRatio.Queries.GetLoanToValueRatio;

public record GetLoanToValueRatioQuery : IRequest<string>
{
    public required double LoanAmount { get; set; }

    public required double SecurityAmount { get; set; }
}

public class GetLoanToValueRatioQueryHandler : IRequestHandler<GetLoanToValueRatioQuery, string>
{
    #region Fields

    private readonly ILvrService _lvrService;

    #endregion

    #region Ctor

    public GetLoanToValueRatioQueryHandler(
        ILvrService lvrService)
    {
        _lvrService = lvrService;
    }

    #endregion

    #region Methods

    public async Task<string> Handle(GetLoanToValueRatioQuery request, CancellationToken cancellationToken)
    {
        return await _lvrService.CalculateLVR(request.LoanAmount, request.SecurityAmount);
    }

    #endregion
}

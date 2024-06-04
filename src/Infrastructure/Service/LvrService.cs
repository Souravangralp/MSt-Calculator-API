using MSt_Calculator_API.Application.Common.Interfaces.CalculatorServices;

namespace CalculatorAPI.Infrastructure.Services;

public class LvrService : ILvrService
{
    #region Methods

    public async Task<string> CalculateLVR(double loanAmount, double securityAmount)
    {
        double lvr = Math.Round((loanAmount / securityAmount) * 100, 2, MidpointRounding.AwayFromZero);

        return await Task.FromResult(string.Format($"{Convert.ToString(lvr)}%"));
    }

    #endregion
}

namespace MSt_Calculator_API.Application.Common.Interfaces.CalculatorServices;

public interface ILvrService
{
    Task<string> CalculateLVR(double loanAmount, double securityAmount);
}

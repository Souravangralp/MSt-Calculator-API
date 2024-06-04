using CalculatorAPI.Domain.Enums;

namespace MSt_Calculator_API.Application.Common.Interfaces.CalculatorServices;

public interface ILandSizeService
{
    Task<string> ConvertLandSizeToHectares(LandConversionTypes conversionTypeId, double landSize);
}

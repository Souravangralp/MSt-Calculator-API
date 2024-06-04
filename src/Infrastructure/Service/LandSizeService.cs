using CalculatorAPI.Application.Common.Utility;
using CalculatorAPI.Domain.Enums;
using MSt_Calculator_API.Application.Common.Interfaces.CalculatorServices;

namespace CalculatorAPI.Infrastructure.Services;

public class LandSizeService : ILandSizeService
{
    #region Methods

    public async Task<string> ConvertLandSizeToHectares(LandConversionTypes conversionTypeId, double landSize)
    {
        switch (conversionTypeId)
        {
            case LandConversionTypes.MeterSquare:
                return await Task.FromResult(CalculatorsUtility.SquareMetersToHectares(landSize).ToString("F2"));
            case LandConversionTypes.Acres:
                return await Task.FromResult(CalculatorsUtility.AcresToHectares(landSize).ToString("F2"));
            default:
                throw new NotImplementedException();
        }
    }

    #endregion
}

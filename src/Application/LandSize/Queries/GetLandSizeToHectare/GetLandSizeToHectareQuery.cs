using System.ComponentModel.DataAnnotations;
using CalculatorAPI.Domain.Enums;
using MSt_Calculator_API.Application.Common.Interfaces.CalculatorServices;

namespace CalculatorAPI.Application.LandSize.Queries.GetLandSizeToHectare;

public class GetLandSizeToHectareQuery : IRequest<string>
{
    public required double LandSize { get; set; }

    [DeniedValues(LandConversionTypes.Acres)]
    public LandConversionTypes ConversionTypeId { get; set; }
}

public class GetLandSizeToHectareQueryHandler : IRequestHandler<GetLandSizeToHectareQuery, string>
{
    #region Fields

    private readonly ILandSizeService _landSizeService;

    #endregion

    #region Ctor

    public GetLandSizeToHectareQueryHandler(ILandSizeService landSizeService)
    {
        _landSizeService = landSizeService;
    }

    #endregion

    #region Methods

    public async Task<string> Handle(GetLandSizeToHectareQuery request, CancellationToken cancellationToken)
    {
        return await _landSizeService.ConvertLandSizeToHectares(request.ConversionTypeId, request.LandSize);
    }

    #endregion
}

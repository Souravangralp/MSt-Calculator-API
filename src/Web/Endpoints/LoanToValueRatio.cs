using CalculatorAPI.Application.LoanToValueRatio.Queries.GetLoanToValueRatio;
using NSwag.Annotations;

namespace CalculatorAPI.Web.Endpoints;

public class LoanToValueRatio : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapGet(GetLVR, "CalculateLvr");
    }

    [OpenApiOperation("Calculate loan to value ratio", "Get loan to value ratio based on security amount and loan amount. ")]
    public async Task<string> GetLVR(ISender sender, [AsParameters] GetLoanToValueRatioQuery query)
    {
        return await sender.Send(query);
    }
}

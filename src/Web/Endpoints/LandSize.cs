using CalculatorAPI.Application.LandSize.Queries.GetLandSizeToHectare;
using NSwag.Annotations;

namespace CalculatorAPI.Web.Endpoints;

public class LandSize : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapGet(GetLandSizeToHectareQuery, "CalculateLandSizeIntoHectare");
    }

    [OpenApiOperation("Calculate land size to hectare", "Get land size calculated in hectares from meters square and acres. (1 denotes to meter squares whereas 2 denotes to acres)")]
    public async Task<string> GetLandSizeToHectareQuery(ISender sender, [AsParameters] GetLandSizeToHectareQuery query)
    {
        return await sender.Send(query);
    }
}

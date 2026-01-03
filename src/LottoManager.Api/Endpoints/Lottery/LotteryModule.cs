using LottoManager.Api.Mapping;
using LottoManager.Application.Services;
using LottoManager.Contracts.Requests.Lottery;

namespace LottoManager.Api.Endpoints.Lottery;

public static class LotteryModule
{
    public static void AddLotteryModule(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.Lottery.Create, async (
            CreateLotteryRequest request,
            ILotteryService lotteryService,
            CancellationToken token) =>
        {
            var lottery = request.MapToLottery();
            var result = await lotteryService.CreateAsync(lottery, token);
            var response = result.MapToCreateResponse();
            return Results.Created($"/lottery/{response.Slug}", response);
        });
    }
}
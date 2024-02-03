using System.Net;
using System.Text.Json;
using FluentValidation;
using func_shops.Models;
using func_shops.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace func_shops.Functions;

public class UpsertShop
{
    private readonly IValidator<Shop> _storeValidator;
    private readonly IShopService _shopService;

    public UpsertShop(IValidator<Shop> storeValidator, IShopService shopService)
    {
        _storeValidator = storeValidator;
        _shopService = shopService;
    }
    
    [Function(nameof(UpsertShop))]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "upsert")] HttpRequestData req,
        FunctionContext executionContext, CancellationToken cancellationToken)
    {
        var logger = executionContext.GetLogger("Create");
        logger.LogInformation("C# HTTP trigger function processed a request.");

        try
        {
            var store = await JsonSerializer.DeserializeAsync<Shop>(req.Body);
            await _storeValidator.ValidateAndThrowAsync(store, cancellationToken);

            await _shopService.UpsertShopAsync(store);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            
            return response;
        }
        catch (JsonException jsonEx)
        {
            var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await errorResponse.WriteStringAsync($"Invalid JSON format: {jsonEx.Message}");
            return errorResponse;
        }
        catch (ValidationException ex)
        {
            var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await errorResponse.WriteStringAsync($"Invalid JSON format: {ex.Message}");
            return errorResponse;
        }
        catch (Exception ex)
        {
            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteStringAsync($"An error occurred: {ex.Message}");
            return errorResponse;
        }
    }
}
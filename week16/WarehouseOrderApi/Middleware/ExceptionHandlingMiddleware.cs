using System.Net;
using System.Text.Json;
using WarehouseOrderApi.Exceptions;
namespace WarehouseOrderApi.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    public ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)

    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Call the next middleware in the pipeline
            await _next(context);
        }
        catch (ProductNotFoundException ex)
        {
            _logger.LogWarning(ex, "Product not found: {ProductId}", ex.ProductId);
            await HandleProductNotFoundException(context, ex);
        }
        catch (InsufficientInventoryException ex)
        {
            _logger.LogWarning(ex, "Insufficient inventory for product {ProductId}", ex.ProductId);
            await HandleInsufficientInventoryException(context, ex);
        }

        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex, "Invalid argument: {Message}", ex.Message);
            await HandleArgumentException(context, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred");
            await HandleGenericException(context, ex);
        }
    }
    private static async Task HandleProductNotFoundException(
    HttpContext context,
    ProductNotFoundException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.NotFound; // 404
        context.Response.ContentType = "application/json";
        var response = new
        {
            type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            title = "Product Not Found",
            status = 404,

            detail = ex.Message,
            productId = ex.ProductId
        };
        var json = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(json);
    }
    private static async Task HandleInsufficientInventoryException(
    HttpContext context,
    InsufficientInventoryException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity; // 422
        context.Response.ContentType = "application/json";
        var response = new
        {
            type = "https://tools.ietf.org/html/rfc4918#section-11.2",
            title = "Insufficient Inventory",
            status = 422,
            detail = ex.Message,
            productId = ex.ProductId,
            requestedQuantity = ex.RequestedQuantity,
            availableQuantity = ex.AvailableQuantity

        };
        var json = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(json);
    }
    private static async Task HandleArgumentException(
    HttpContext context,
    ArgumentException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest; // 400
        context.Response.ContentType = "application/json";
        var response = new
        {
            type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            title = "Bad Request",
            status = 400,
            detail = ex.Message
        };
        var json = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(json);
    }
    private static async Task HandleGenericException(
    HttpContext context,

    Exception ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // 500
        context.Response.ContentType = "application/json";
        var response = new
        {
            type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            title = "Internal Server Error",
            status = 500,
            detail = "An unexpected error occurred. Please contact support."
        };
        var json = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(json);
    }
}
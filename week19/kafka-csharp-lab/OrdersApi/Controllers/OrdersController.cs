using Microsoft.AspNetCore.Mvc;
using OrdersApi.Models;
using OrdersApi.Services;

namespace OrdersApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly KafkaConsumerService _kafkaConsumer;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(
        KafkaConsumerService kafkaConsumer,
        ILogger<OrdersController> logger)
    {
        _kafkaConsumer = kafkaConsumer;
        _logger = logger;
    }

    [HttpGet("next")]
    public ActionResult<Order> GetNextOrder()
    {
        _logger.LogInformation(
            "Attempting to consume next order from Kafka"
        );

        var order = _kafkaConsumer.ConsumeNextOrder(
            TimeSpan.FromSeconds(5)
        );

        if (order == null)
        {
            _logger.LogInformation("No orders available");

            return NotFound(new
            {
                message = "No orders available"
            });
        }

        _logger.LogInformation(
            "Order {OrderId} retrieved successfully",
            order.OrderId
        );

        return Ok(order);
    }
}
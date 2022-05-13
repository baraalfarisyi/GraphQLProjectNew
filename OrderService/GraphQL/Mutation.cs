using HotChocolate.AspNetCore.Authorization;
using Library.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OrderService.Kafka;
using System.Security.Claims;

namespace OrderService.GraphQL
{
    public class Mutation
    {

        [Authorize]
        public async Task<OrderData> SubmitOrderAsync(OrderKafka input, ClaimsPrincipal claimsPrincipal, [Service] IOptions<KafkaSettings> settings)
        {
            var userName = claimsPrincipal.Identity.Name;

            var order = new OrderData
            {
                Code = Guid.NewGuid().ToString(),
                UserName = userName
            };

            List<ODetail> details = new();
            foreach (var item in input.Details)
            {
                var detail = new ODetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                details.Add(detail);
            }
            order.Details = details;
            var dts = DateTime.Now.ToString();
            var key = "order-" + dts;
            var val = JsonConvert.SerializeObject(order);

            var result = await KafkaHelper.SendMessage(settings.Value, "studycase", key, val);
            return order;
        }

    }
}

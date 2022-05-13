using HotChocolate.AspNetCore.Authorization;
using Library.Models;
using System.Security.Claims;

namespace OrderService.GraphQL
{
    public class Mutation
    {

        public async Task<OrderDetail> AddOrderAsync(OrderData input, ClaimsPrincipal claimsPrincipal, [Service] StudyCaseDbContext context)
        {
            string userName = claimsPrincipal.Identity.Name;
            var user = context.Users.Where(u => u.Username == userName).FirstOrDefault();
            if (user == null) return new OrderDetail();

            var order = new Order { Code = input.Code, UserId = user.Id };

            context.Orders.Add(order);
            await context.SaveChangesAsync();

            var orderDetail = new OrderDetail
            {
                OrderId = order.Id,
                ProductId = input.ProductId,
                Quantity = input.Quantity,
            };

            var result = context.OrderDetails.Add(orderDetail);
            await context.SaveChangesAsync();

            return result.Entity;
        }

    }
}

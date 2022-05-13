namespace OrderService.GraphQL
{
    public record OrderInput
    (
        int ProductId,
        int? UserId,
        int Quantity
    );
}

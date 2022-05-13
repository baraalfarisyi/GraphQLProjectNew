using Library.Models;

namespace OrderService.GraphQL
{
    public class OrderKafka
    {
        public int? Id { get; set; }
        public string? Code { get; set; }
        public int? UserId { get; set; }
        public List<ODetail> Details { get; set; }
    }
}

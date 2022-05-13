using Library.Models;

namespace ProductService.GraphQL
{
    public class Query
    {
        public IQueryable<Product> GetProducts([Service] StudyCaseDbContext context) =>
            context.Products;
    }
}

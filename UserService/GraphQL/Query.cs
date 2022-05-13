using HotChocolate.AspNetCore.Authorization;
using Library.Models;

namespace UserService.GraphQL
{
    public class Query
    {
        [Authorize(Roles = new[] { "ADMIN" })]
        public IQueryable<UserData> GetUsers([Service] StudyCaseDbContext context) =>
            context.Users.Select(p => new UserData()
            {
                Id = p.Id,
                FullName = p.FullName,
                Email = p.Email,
                Username = p.Username
            });
    }
}

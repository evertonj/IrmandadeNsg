using IrmandadeNsg.Domain.Models;

namespace IrmandadeNsg.Domain.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Post GetByEmail(string email);
    }
}

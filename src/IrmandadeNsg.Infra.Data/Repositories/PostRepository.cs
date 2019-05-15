using IrmandadeNsg.Domain.Interfaces;
using IrmandadeNsg.Domain.Models;
using IrmandadeNsg.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IrmandadeNsg.Infra.Data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(IrmandadeContext context) : base(context){}

        public Post GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(post => post.Author.Email == email);
        }
    }
}

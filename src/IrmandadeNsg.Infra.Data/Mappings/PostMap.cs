using IrmandadeNsg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IrmandadeNsg.Infra.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(post => post.Title).HasMaxLength(150).IsRequired();
            builder.Property(post => post.Body).HasMaxLength(35000000).IsRequired();
            builder.Property(post => post.Image).IsRequired();
            builder.Property(post => post.Description).IsRequired();
            builder.Property(post => post.Tags).IsRequired();
            builder.Property(post => post.Category).IsRequired();
            builder.Property(post => post.Created).IsRequired();
            builder.Property(post => post.MainComments).IsRequired();
        }
    }
}

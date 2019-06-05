using IrmandadeNsg.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IrmandadeNsg.Infra.Data.Mappings
{
    public class MainCommentMap : IEntityTypeConfiguration<MainComment>
    {
        public void Configure(EntityTypeBuilder<MainComment> builder)
        {
            builder.HasMany(m => m.SubComments);
        }
    }
}

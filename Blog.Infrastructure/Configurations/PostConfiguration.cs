using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");

        builder.Property(t => t.Title).IsRequired().HasMaxLength(200);

        builder.HasOne(p => p.User).WithMany(u => u.Posts)
               .HasForeignKey(p => p.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade); ;
    }
}


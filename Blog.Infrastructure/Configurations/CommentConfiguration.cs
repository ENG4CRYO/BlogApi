using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{     
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasOne(p => p.Post).WithMany(c => c.Comments).HasForeignKey(p => p.PostId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.User).WithMany(c => c.Comments).HasForeignKey(u => u.UserId)
            .IsRequired().OnDelete(DeleteBehavior.Restrict);


    }
}


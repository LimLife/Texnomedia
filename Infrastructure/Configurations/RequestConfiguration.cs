using Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Description);
            builder.Property(r => r.CreationDate);
            builder.Property(a => a.Status).HasConversion(status => status.ToString(), status => (RequestStatus)Enum.Parse(typeof(RequestStatus), status));
            builder.HasMany(r => r.Assignments)
                      .WithOne(a => a.Request)
                      .HasForeignKey(a => a.RequestId)
                      .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

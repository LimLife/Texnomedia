using Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Description);
            builder.Property(a => a.AssignmentDate);
            builder.Property(a => a.CompletionDate);
            builder.Property(a => a.Status).HasConversion(status=> status.ToString(), status => (AssignmentStatus)Enum.Parse(typeof(AssignmentStatus), status));
            builder.Property(a => a.Notes);
            builder.HasMany(a => a.GeologicalSurveys)
                   .WithOne(g => g.Assignment)
                   .HasForeignKey(g => g.AssignmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

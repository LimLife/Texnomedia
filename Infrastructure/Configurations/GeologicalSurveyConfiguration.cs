using Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configurations
{
    public class GeologicalSurveyConfiguration : IEntityTypeConfiguration<GeologicalSurvey>
    {
        public void Configure(EntityTypeBuilder<GeologicalSurvey> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.SurveyType).HasConversion(status => status.ToString(), status => (SurveyType)Enum.Parse(typeof(SurveyType), status));
            builder.Property(g => g.Result);
            builder.Property(g => g.SurveyDate);
        }
    }
}

using Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name);
            builder.Property(b => b.TypeBrigade).HasConversion(type => type.ToString(), type => (TypeTeam)Enum.Parse(typeof(TypeTeam), type)); ;
        }
    }
}

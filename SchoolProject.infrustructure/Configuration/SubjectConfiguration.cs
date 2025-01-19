using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.infrustructure.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subjects>
    {
        public void Configure(EntityTypeBuilder<Subjects> builder)
        {
            builder.Property(s => s.Period)
                .HasColumnType("integer");
        }
    }
}

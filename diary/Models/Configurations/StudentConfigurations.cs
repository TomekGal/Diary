using diary.Models.Domains;
using System.Data.Entity.ModelConfiguration;

namespace diary.Models.Configurations
{
    public class StudentConfigurations : EntityTypeConfiguration<Student>
    {

        public StudentConfigurations()
        {
            ToTable("dbo.Students");
            HasKey(x => x.Id);

            Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}

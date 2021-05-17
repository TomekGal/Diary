using diary.Models.Domains;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace diary.Models.Configurations 
{
   public class GroupConfigurations : EntityTypeConfiguration<Group>
    {
    public GroupConfigurations()
    {
            ToTable("dbo.Groups");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();
    }

    }
}

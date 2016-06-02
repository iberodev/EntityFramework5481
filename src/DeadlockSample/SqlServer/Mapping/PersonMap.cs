using DeadlockSample.Model;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeadlockSample.SqlServer.Mapping
{
    public class PersonMap
    {
        public PersonMap(EntityTypeBuilder<Person> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);

            entityBuilder.Property(p => p.Name)
                .IsRequired(true);

            entityBuilder.HasOne(p => p.AddressOne)
                .WithMany()
                .HasForeignKey(p => p.AddressOneId)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.Property(p => p.AddressOneId);

            entityBuilder.HasOne(p => p.AddressTwo)
                .WithMany()
                .HasForeignKey(p => p.AddressTwoId)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.Property(p => p.AddressTwoId);
        }
    }
}

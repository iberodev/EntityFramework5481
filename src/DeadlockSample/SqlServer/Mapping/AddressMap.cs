using DeadlockSample.Model;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeadlockSample.SqlServer.Mapping
{
    public class AddressMap
    {
        public AddressMap(EntityTypeBuilder<Address> entityBuilder)
        {
            entityBuilder.HasKey(a => a.Id);

            entityBuilder.Property(a => a.Street)
                .IsRequired(true);

            entityBuilder.HasOne(a => a.Person)
                .WithMany()
                .HasForeignKey(a => a.PersonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

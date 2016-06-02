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
                .WithOne(a => a.Person)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasOne(p => p.AddressTwo)
                .WithOne(a => a.Person)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

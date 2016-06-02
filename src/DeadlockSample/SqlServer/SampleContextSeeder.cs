using DeadlockSample.Model;
using System.Linq;

namespace DeadlockSample.SqlServer
{
    public class SampleContextSeeder
    {
        private readonly SampleContext _context;

        public SampleContextSeeder(SampleContext context)
        {
            _context = context;
        }
        public void EnsureSeedData()
        {
            if(!_context.Persons.Any())
            {
                var persons = GetPersons();
                _context.AddRange(persons);
                _context.SaveChanges();
            }
        }

        private Person [] GetPersons()
        {
            var persons = new Person[]
            {
                new Person { Name = "John Doe" },
                new Person { Name = "Joe Bloggs" }
            };
            return persons;
        }
    }
}

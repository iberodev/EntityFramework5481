using DeadlockSample.Model;
using DeadlockSample.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DeadlockSample.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SampleContext _context;

        public PersonRepository(SampleContext context)
        {
            _context = context;
        }

        private IQueryable<Person> GetPersonQueryable(string street)
        {
            var peopleQuery = _context.Persons
                    .Include(p => p.AddressOne)
                    .Include(p => p.AddressTwo)
                    .Where(p => (p.AddressOne != null && p.AddressOne.Street.Contains(street))
                            || (p.AddressTwo != null && p.AddressTwo.Street.Contains(street)));
            return peopleQuery;
        }

        public async Task<int> GetPersonCountAsync(string street)
        {
            var count1 = await _context.Persons.CountAsync(); //this works well
            var peopleQuery = GetPersonQueryable(street);
            var count2 = peopleQuery.Count(); //this works well
            var count3 = await peopleQuery.CountAsync(); //this DOES NOT work. No exception, just deadlock
            return count3; //this never executes
        }
    }
}

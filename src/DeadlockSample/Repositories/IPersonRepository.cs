using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeadlockSample.Repositories
{
    public interface IPersonRepository
    {
        Task<int> GetPersonCountAsync(string street);
    }
}

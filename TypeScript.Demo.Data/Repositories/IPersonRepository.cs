using ArchitectNow.Framework.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using TypeScript.Demo.Data.Models;

namespace TypeScript.Demo.Data.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<List<Person>> SearchPeople(string SearchString);
    }
}
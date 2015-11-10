using ArchitectNow.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeScript.Demo.Data.Models;

namespace TypeScript.Demo.Data.Repositories
{
    public class MoqPersonRepository : BaseMoqRepository<Person>, IPersonRepository
    {

        public MoqPersonRepository()
        {


            Data.Add(new Person() { NameFirst = "Kevin", DateOfBirth = new DateTime(1975, 1, 1) });
            Data.Add(new Person() { NameFirst = "Chris", DateOfBirth = new DateTime(1976, 1, 1) });
            Data.Add(new Person() { NameFirst = "George", DateOfBirth = new DateTime(1977, 1, 1) });
            Data.Add(new Person() { NameFirst = "Dule", DateOfBirth = new DateTime(1978, 1, 1) });
            Data.Add(new Person() { NameFirst = "Lynda", DateOfBirth = new DateTime(1979, 1, 1) });
            Data.Add(new Person() { NameFirst = "Alexis", DateOfBirth = new DateTime(1980, 1, 1) });

            this.DataQuery = Data.AsQueryable();
        }

        public async Task<List<Person>> SearchPeople(string SearchString)
        {
            return await Task.Run(() => DataQuery.Where(x => x.NameFirst.ToUpper().Contains(SearchString.ToUpper())).ToList());
        }

  
    }
}

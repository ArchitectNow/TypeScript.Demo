using ArchitectNow.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectNow.Framework.Repositories
{
    public abstract class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntity
    {
        public BaseRepository()
        {

        }

        public void Dispose()
        {
           
        }

        public virtual async Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> Get(Guid ID)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> Update(T Item)
        {
            throw new NotImplementedException();
        }

        public virtual async Task Delete(Guid ID)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> DataQuery { get; set; }

    }
}

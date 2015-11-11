using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArchitectNow.Framework.Models;
using System.Linq;

namespace ArchitectNow.Framework.Repositories
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        Task Delete(Guid ID);
        Task DeleteAll();
        Task<T> Get(Guid ID);
        Task<List<T>> GetAll();
        Task<T> Update(T Item);
        IQueryable<T> DataQuery { get; set; }
    }
}
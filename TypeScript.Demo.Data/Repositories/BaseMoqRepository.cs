using ArchitectNow.Framework.Models;
using ArchitectNow.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeScript.Demo.Data.Repositories
{
    public abstract class BaseMoqRepository<T> : BaseRepository<T> where T : BaseEntity
    {
        public BaseMoqRepository()
        {
            Data = new List<T>();
        }

        protected List<T> Data { get; set; }

        public override async Task<List<T>> GetAll()
        {
            if (DataQuery == null)
            {
                throw new ApplicationException("DataQuery not set");
            }

            return await Task.Run(() => DataQuery.ToList());
        }

        public override async Task<T> Get(Guid ID)
        {
            if (DataQuery == null)
            {
                throw new ApplicationException("DataQuery not set");
            }

            return await Task.Run(() => DataQuery.FirstOrDefault(x => x.ID == ID));
        }

        public override async Task<T> Update(T Item)
        {
            if (DataQuery == null)
            {
                throw new ApplicationException("DataQuery not set");
            }

            // No need to do anything
            var _existingItem = await Get(Item.ID);

            Item.LastEdited = DateTime.UtcNow;

            if (_existingItem != null)
            {
                Data.Remove(_existingItem);
            }

            Data.Add(Item);

            DataQuery = Data.AsQueryable();

            return Item;
        }

        public override async Task Delete(Guid ID)
        {
            if (DataQuery == null)
            {
                throw new ApplicationException("DataQuery not set");
            }

            var _existingItem = await Get(ID);

            if (_existingItem == null)
            {
                Data.Remove(_existingItem);

                DataQuery = Data.AsQueryable();
            }
        }

        public override async Task DeleteAll()
        {
            await Task.Run(() =>
            {
                Data = new List<T>();
                DataQuery = Data.AsQueryable();
            });
        }

    }
}

using ArchitectNow.Framework.Models;
using ArchitectNow.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Data.Entity;

namespace TypeScript.Demo.Areas.API.Controllers
{
    public abstract class BaseDataController<TEntity> : BaseApiController where TEntity : BaseEntity
    {
        public IBaseRepository<TEntity> Repository { get; set; }

        public BaseDataController()
        {

        }

        #region ReturnHelpers


        protected PagedResultEnvelope<T> BuildPagedResultError<T>(Exception exception)
        {
            var message = exception.Message;
            var aggregateException = exception as AggregateException;
            if (aggregateException != null)
            {
                message = aggregateException.Flatten().Message;
            }

            var entityException = exception as EntityException;
            if (entityException != null)
            {
                message = entityException.GetBaseException().Message;
            }

            return BuildPagedResultError<T>(message, exception);
        }

        protected PagedResultEnvelope<T> BuildPagedResultError<T>(string message, Exception exception = null)
        {
            return new PagedResultEnvelope<T> { Success = false, Message = message };
        }

        protected PagedResultEnvelope<T> BuildPagedResult<T>(bool success, string message, IEnumerable<T> items, int page, int limit, long total)
        {
            if (items == null)
            {
                return new PagedResultEnvelope<T> { Success = success, Message = message };
            }

            return new PagedResultEnvelope<T>(items, page, limit, total)
            {
                Message = message,
                Success = success
            };
        }

        #endregion

        [HttpGet]
        public virtual async Task<PagedResultEnvelope<TEntity>> GetAll([QueryString] int page = 0, [QueryString] int limit = 25)
        {
            try
            {
                var result = GetPagedResult(Repository.DataQuery, page, limit);
                return result;
            }
            catch (Exception exception)
            {
                return BuildPagedResultError<TEntity>(exception);
            }
        }

        [HttpGet]
        public virtual async Task<Envelope<TEntity>> Get(Guid id)
        {
            return await Get(id, () => Repository.DataQuery);
        }


        protected virtual async Task<Envelope<TEntity>> Get(Guid id, Func<IQueryable<TEntity>> getQueryable)
        {
            try
            {
                var query = getQueryable();

                var result = await query.FirstOrDefaultAsync(entity => entity.ID == id);
                return BuildResult(true, string.Empty, result);
            }
            catch (Exception exception)
            {
                return BuildResultError<TEntity>(exception);
            }
        }


        [HttpPut]
        public virtual async Task<Envelope<TEntity>> Put(TEntity entity)
        {
            return await TryRun(() => Repository.Update(entity));
        }

        [HttpPost]
        public virtual async Task<Envelope<TEntity>> Post(TEntity entity)
        {
            return await TryRun(() => Repository.Update(entity));
        }

        protected virtual async Task<Envelope<TEntity>> TryRun(Func<Task<TEntity>> func)
        {
            try
            {
                var result = await func();
                return BuildResult(true, string.Empty, result);
            }
            catch (Exception exception)
            {
                return BuildResultError<TEntity>(exception);
            }
        }

        [HttpDelete]
        public virtual async Task<Envelope<TEntity>> Delete(Guid id)
        {
            try
            {
                await Repository.Delete(id);
                return BuildResult<TEntity>(true, string.Empty, null);
            }
            catch (Exception exception)
            {
                return BuildResultError<TEntity>(exception);
            }
        }

        [HttpGet]
        protected async Task<PagedResultEnvelope<TEntity>> Search(Expression<Func<TEntity, bool>> searchExpression, int page = 0, int limit = 25, params Expression<Func<TEntity, string>>[] orderBys)
        {
            var queryable = Repository.DataQuery.Where(searchExpression);

            foreach (var orderBy in orderBys)
            {
                queryable = queryable.OrderBy(orderBy);
            }

            return GetPagedResult(queryable, page, limit);
        }

        protected async Task<PagedResultEnvelope<TEntity>> AllActive(int page = 0, int limit = 25, params Expression<Func<TEntity, string>>[] orderBys)
        {
            var queryable = Repository.DataQuery;

            foreach (var orderBy in orderBys)
            {
                queryable = queryable.OrderBy(orderBy);
            }

            return GetPagedResult(queryable, page, limit);
        }

        protected PagedResultEnvelope<T> GetPagedResult<T>(IQueryable<T> queryable, int page = 0, int limit = 25) where T : BaseEntity 
        {
            var totalCount = queryable.Count();
            var items = queryable
                .OrderByDescending(arg => arg.LastEdited)
                .Skip(page * limit).Take(limit).ToList();

            return BuildPagedResult(true, string.Empty, items, page, limit, totalCount);
        }
    }
}

using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using KPMG.Infrastructure.Data.Infrasructure;
using KPMG.Infrastructure.Helper;

namespace KPMG.Data.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: Entity 
    {
        private readonly IContentContext _contentContext;

        public IContentContext ContentContext
        {
            get { return _contentContext; }
        }
        
        IDbSet<TEntity> GetDbSet()
        {
            return _contentContext.CreateSet<TEntity>();
        }

        public Repository(IContentContext contentContext)
        {
            if (contentContext == null)
                throw new ArgumentNullException("missing dbContent");

            _contentContext = contentContext;
        }

        public void Insert(params TEntity[] items)
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    // generate new Id
                    item.GenerateNewIdentity();
                    // check trackable item for create
                    if (item.GetType().GetInterfaces().Contains(typeof (ITrackable)))
                    {
                        var tracker = (ITrackable) item;
                        UpdateTrackableItem(tracker);
                    }
                    GetDbSet().Add(item);
                }
                else
                {
                    //TODO create null error log later
                }
            }
        }

        public void Delete(params object[] id)
        {
            Delete(GetDbSet().Find(id));
        }

        public void Delete(TEntity item)
        {
            if (item != null)
            {
                _contentContext.Attach(item);
                GetDbSet().Remove(item);
            }
            else
            {
                //TODO create null error log
            }
        }

        public void Update(TEntity item)
        {
            if (item != null)
                _contentContext.SetModified(item);
            else
            {
                //TODO create null error log
            }
        }

        public void TrackItem(TEntity item)
        {
            if (item != null)
                _contentContext.Attach(item);
            else
            {
                //TODO create null error log
            }
        }

        public void Merge(TEntity persisted, TEntity current)
        {
            _contentContext.ApplyCurrentValues(persisted, current);
        }

        public TEntity GetById(params object[] id)
        {
            if (id != null)
                return GetDbSet().Find(id);
            return null;
        }

        /// <summary>
        /// Get list of result by query
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="pageNumber">page number: only works when orderBy is given</param>
        /// <param name="pageSize">page size: only works when orderBy is given</param>
        /// <returns></returns>
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int pageNumber = -1,
            int pageSize = 10)
        {
            IQueryable<TEntity> query = GetDbSet();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
            {
                query = orderBy(query);
                if (pageNumber > 0)
                    query = query.Skip((pageNumber - 1)*pageSize).Take(pageSize);
            }

            query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
           
#if DEBUG
            Debug.WriteLine("Query Linq: " + query);
#endif
            return query;
        }

        public void Dispose()
        {
            if (_contentContext != null)
                _contentContext.Dispose();
        }

        private void UpdateTrackableItem(ITrackable tracker)
        {
            var timeNow = DateTimeHelper.CurrentDateTime;
            if (tracker.CreatedDate == default(DateTime))
                tracker.CreatedDate = timeNow;
        }
    }
}

using System.Data.Entity;
using KPMG.Infrastructure.Data.Entity;
using KPMG.Infrastructure.Data.Infrasructure;

namespace KPMG.Data.Infrastructure
{
    public class ContentContext : DbContext, IContentContext
    {

        #region tables

        // Clients
        public IDbSet<TransactionData> TransactionData { get; set; }
        #endregion

        public ContentContext() : base("name=KPMG")
        {
        }

        #region methods

        public virtual IDbSet<TEntity> CreateSet<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>();
        }

        public virtual void Attach<TEntity>(TEntity entity) where TEntity : Entity
        {
            base.Entry(entity).State = EntityState.Unchanged;
        }

        public virtual void SetModified<TEntity>(TEntity entity) where TEntity : Entity
        {
            var entry = base.Entry(entity);
            var set = CreateSet<TEntity>();
            TEntity attachedEntity = set.Find(entity.Id);
            if (attachedEntity != null)
                ApplyCurrentValues(attachedEntity, entity);
            else
                entry.State = EntityState.Modified;
        }

        public virtual void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : Entity
        {
            base.Entry(original).CurrentValues.SetValues(current);
        }

        #endregion

    }
}

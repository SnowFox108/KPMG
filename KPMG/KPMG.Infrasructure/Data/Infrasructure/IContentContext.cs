using System;
using System.Data.Entity;
using KPMG.Infrasructure.Data.Entity;

namespace KPMG.Infrasructure.Data.Infrasructure
{
    public interface IContentContext : IDisposable
    {
        #region tables

        IDbSet<TransactionData> TransactionData { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Returns a IDbSet instance for access to entities of the given type in the context, 
        /// the ObjectStateManager, and the underlying store. 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : Entity;

        /// <summary>
        /// Attach this item into "ObjectStateManager"
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="entity">The item </param>
        void Attach<TEntity>(TEntity entity) where TEntity : Entity;

        /// <summary>
        /// Set object as modified
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="entityToUpdate">The entity item to set as modifed</param>
        void SetModified<TEntity>(TEntity entityToUpdate) where TEntity : Entity;

        /// <summary>
        /// Apply current values in <paramref name="original"/>
        /// </summary>
        /// <typeparam name="TEntity">The type of entity</typeparam>
        /// <param name="original">The original entity</param>
        /// <param name="current">The current entity</param>
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : Entity;

        /// <summary>
        /// Commit save changes
        /// </summary>
        int SaveChanges();

        #endregion
    }
}

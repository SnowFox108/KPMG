﻿using System;

namespace KPMG.Infrastructure.Data.Infrasructure
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Get the unit of work in this repository
        /// </summary>
        IContentContext ContentContext { get; }

        /// <summary>
        /// Commit all changes to database
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Get repository of entity
        /// </summary>
        /// <typeparam name="TEntity">Entity name</typeparam>
        /// <returns>Entity</returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;
    }
}

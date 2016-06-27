using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Infra.Data.Context;
using Infra.Data.Interface;

namespace Infra.Data.Repository
{
    /// <summary>
    /// Encapsulates the available database interactions on behalf of a Repository type.
    /// </summary>
    /// <typeparam name="T">Any type of class available in the Opendesk.Models namespace.
    /// </typeparam>
    /// <remarks>
    /// The RepositoryBase type exposes the following members.
    /// </remarks>
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private Contexto _db;
        private readonly IDbSet<T> _dbset;

        /// <summary>
        /// Holds a reference to the DatabaseFactory class used to manage connections to the database.
        /// </summary>
        protected IDatabaseFactory DatabaseFactory { get; private set; }

        /// <summary>
        /// Contains a reference to the <see cref="System.Data.Entity.DbContext"/> instance used by the repository.
        /// </summary>
        protected Contexto Context { get { return _db ?? (_db = DatabaseFactory.Get()); } }

        /// <summary>
        /// Initialises a new instance of the RepositoryBase class.
        /// </summary>
        /// <param name="dbFactory">A valid DatabaseFactory <see cref="ModelagemLib.DatabaseFactory"/> object.</param>
        protected BaseRepository()
        {
            DatabaseFactory = new DatabaseFactory();
            _dbset = Context.Set<T>();
        }

        /// <summary>
        /// Adds a new entity instance to the database on behalf of the parent type.
        /// </summary>
        /// <param name="entity">Any valid database object</param>
        public virtual bool Create(T entity)
        {
            _dbset.Add(entity);
            _db.Commit();

            return true;
        }

        /// <summary>
        /// Returns a specific instance of an entity from the database on behalf of the parent type.
        /// </summary>
        /// <param name="id">The integer value of the entity's primary key</param>
        /// <returns>A database object (of type T)</returns>
        public virtual T Read(int id)
        {
            return _dbset.Find(id);
        }

        /// <summary>
        /// Returns an IEnumerable collection of all objects found in the database of type T
        /// </summary>
        /// <returns>A collection of type IEnumerable</returns>
        public virtual IEnumerable<T> Read()
        {
            return _dbset.ToList();
        }

        /// <summary>
        /// Updates an existing entity instance in the database on behalf of the parent type.
        /// </summary>
        /// <param name="entity">Any valid database object</param>
        public bool Update(T entity)
        {
            var entry = _db.Entry<T>(entity);

            // Retreive the Id through reflection
            var pkey = _dbset.Create().GetType().GetProperty("Id").GetValue(entity);

            if (entry.State == EntityState.Detached && entry.State == EntityState.Modified)
            {
                var set = _db.Set<T>();
                T attachedEntity = set.Find(pkey); // You need to have access to key
                if (attachedEntity != null)
                {
                    var attachedEntry = _db.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }


            //var tester = ((IObjectContextAdapter)_db).ObjectContext.ObjectStateManager;
            //_dbset.Attach(entity);
            //_db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
            _db.Commit();
            return true;
        }

        /// <summary>
        /// Deletes an existing instance of an entity from the database on behalf of the parent type.
        /// </summary>
        /// <param name="entity">Any valid database object</param>
        public virtual bool Delete(T entity)
        {
            //var entry = _db.Entry<T>(entity);
            //var pkey = _dbset.Create().GetType().GetProperty("Id").GetValue(entity);

            //if (entry.State == EntityState.Detached)
            //{
            //    var set = _db.Set<T>().Remove(entity);

            //}

            _dbset.Remove(entity);
            _db.Commit();

            return true;
        }

        public IEnumerable<T> Read(Expression<System.Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).ToList();
        }

        public void Dispose()
        {
            //_db.Dispose();
        }
    }
}

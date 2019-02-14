using PharmacyApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PharmacyApplication.Business
{
    public class Repository<T> where T:class
    {
        PharmacyDBEntities context;

        public Repository()
        {
            context = new PharmacyDBEntities();
        }

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="entity">Entity to Add</param>
        public void Add(T entity)
        {
            try
            {
                context.Set<T>().Add(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Add a range of Entities 
        /// </summary>
        /// <param name="entities">IEnumerable containing a range of entities</param>
        public void AddRange(IEnumerable<T> entities)
        {
            try
            {
                context.Set<T>().AddRange(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Find using a predicate
        /// </summary>
        /// <param name="predicate">predicate to use to search</param>
        /// <returns>IEnumerable</returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return context.Set<T>().Where(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get a particular record
        /// </summary>
        /// <param name="id">Identity of record</param>
        /// <returns>T where T is a Type</returns>
        public T Get(int id)
        {
            try
            {
                return context.Set<T>().Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get a particular record
        /// </summary>
        /// <param name="id">Identity of record as string</param>
        /// <returns>T where T is a Type</returns>
        public T Get(string id)
        {
            try
            {
                return context.Set<T>().Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>IEnumerable with a list of entities</returns>
        public IEnumerable<T> GetAllList()
        {
            try
            {
                return context.Set<T>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Remove a record
        /// </summary>
        /// <param name="entity">record to remove</param>
        public void Remove(T entity)
        {
            try
            {
                context.Set<T>().Remove(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Remove a range of records
        /// </summary>
        /// <param name="entities">Range of records to remove</param>
        public void RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                context.Set<T>().RemoveRange(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Set State of an Entity
        /// </summary>
        /// <param name="entity">entity</param>
        public void SetState(T entity)
        {
            try
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Save Changes
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (context != null)
                context.Dispose();
        }

    }
}
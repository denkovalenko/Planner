using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

	public class GenericRepository<TEntity> : IDisposable where TEntity : class
	{
		private readonly ApplicationDbContext _dataContext;

		public GenericRepository(ApplicationDbContext dataContext)
		{
			_dataContext = dataContext;
		}

		/// <summary>
		/// Property for heirs
		/// </summary>
		protected DbSet<TEntity> Dbset
		{
			get { return _dataContext.Set<TEntity>(); }
		}

		/// <summary>
		/// Adds an entity to context.
		/// </summary>
		/// <param name="entity">The entity to add.</param>
		/// <returns>Boolean value of success of add operation.</returns>
		public virtual bool Add(TEntity entity)
		{
			_dataContext.Set<TEntity>().Add(entity);
			return true;
		}

		/// <summary>
		/// Updates an entity if it exists.
		/// </summary>
		/// <param name="entity">The entity to update.</param>
		/// <returns>Boolean value of success of update operation.</returns>
		public virtual bool Update(TEntity _entity)
		{
			dynamic entity = _entity;
			var olditem = _dataContext.Set<TEntity>().Find(entity.Id);
			if (olditem == null)
				throw new KeyNotFoundException("No entity with particular id found!");
			_dataContext.Entry<TEntity>(olditem).CurrentValues.SetValues(entity);
			return true;
		}

		/// <summary>
		/// Deletes an entity if it exists.
		/// </summary>
		/// <param name="id">The id of entity.</param>
		/// <returns>Boolean value of success of delete operation.</returns>
		public virtual bool Delete(int id)
		{
			var entity = _dataContext.Set<TEntity>().Find(id);
			if (entity == null)
				throw new KeyNotFoundException("No entity with particular id found!");
			_dataContext.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Deleted;
			_dataContext.Set<TEntity>().Remove(entity);
			return true;
		}

		/// <summary>
		/// Retrieves entities if they exist.
		/// </summary>
		/// <param name="exps">Optional array of expression for including.</param>
		/// <returns>Boolean value of success of retrieve operation.</returns>
		public virtual IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] exps)
		{
			IQueryable<TEntity> query = _dataContext.Set<TEntity>();

			if (exps == null)
			{
				if (query == null || !query.Any())
					throw new ApplicationException("No item found!");
			}
			else
			{
				foreach (var item in exps)
					query = query.Include(item);
			}

			return query;
		}

		/// <summary>
		/// Retrieves entities if they exist by delegate.
		/// </summary>
		/// <param name="lambda">Delegate for selecting.</param>
		/// <param name="exps">Optional array of expression for including.</param>
		/// <returns>Boolean value of success of retrieve operation.</returns>
		public virtual IEnumerable<TEntity> GetBy(Func<TEntity, bool> lambda, params Expression<Func<TEntity, object>>[] exps)
		{
			var entities = _dataContext.Set<TEntity>().Where(lambda).AsEnumerable<TEntity>();
			if (entities == null) throw new ApplicationException("No entities found!");
			return entities;
		}

		/// <summary>
		/// Retrieves entity if it exists.
		/// </summary>
		/// <param name="keys">The values of primary key for the entity to be found.</param>
		/// <returns>Boolean value of success of find operation.</returns>
		public virtual TEntity GetById(params object[] keys)
		{
			var entity = _dataContext.Set<TEntity>().Find(keys);
			if (entity == null) throw new KeyNotFoundException("No entity with particular key(s) found!");
			return entity;
		}

		/// <summary>
		/// Saves changes in context.
		/// </summary>
		/// <returns>Boolean value of success of save operation.</returns>
		public virtual bool Save()
		{
			try
			{
				_dataContext.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void Dispose()
		{
			_dataContext.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}

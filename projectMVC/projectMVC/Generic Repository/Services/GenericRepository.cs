using Microsoft.EntityFrameworkCore;
using projectMVC.Data;
using projectMVC.Generic_Repository.Interfaces;
using projectMVC.Models;
using System.Linq;
using System.Linq.Expressions;

namespace projectMVC.Generic_Repository.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class

    {

        public ApplicationDbContext _context;
        public DbSet<TEntity> _set;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }




        public IQueryable<TEntity> GetAll()
        {
            return _set;
        }
        public IQueryable<TEntity> GetAll(Func<TEntity,bool> Expression)
        {
            return _set.Where(Expression) as IQueryable<TEntity>;
        }
        public TEntity GetById(int id)
        {
            return _set.Find(id);
        }

        public TEntity Create(TEntity entity)
        {
            _set.Add(entity);
            return _context.SaveChanges() > 0 ? entity : null;
        }

        public bool Delete(TEntity entity)
        {
            _set.Remove(entity);
            return _context.SaveChanges() > 0;

        }

        public bool Update(TEntity entity)
        {
            _set.Update(entity);
            return _context.SaveChanges() > 0;

        }

        public IQueryable<TEntity> GetAll(Func<TEntity> Expression)
        {
            throw new NotImplementedException();
        }
		public bool AddRange(List<TEntity> entities)
		{
			_set.AddRange(entities);
			return _context.SaveChanges() > 0;

		}

	}
}

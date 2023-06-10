using System.Linq.Expressions;

namespace projectMVC.Generic_Repository.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        public IQueryable<TEntity> GetAll();
        public IQueryable<TEntity> GetAll(Func<TEntity> Expression);
        public TEntity Create(TEntity entity);
        public bool Delete(TEntity entity);
        public bool Update(TEntity entity);
        public TEntity GetById(int id);
		public bool AddRange(List<TEntity> entities);
	}
}

using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = ""
        );
        TEntity? GetByID(object id);
        IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }

    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<TEntity> _dbset;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return _dbset.FromSqlRaw(query, parameters).ToList();
        }

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach ( var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity? GetByID(object id)
        {
            return _dbset.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(object id)
        {
            TEntity? entityToDelete = GetByID(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
            else
            {
                throw new Exception();
            }
        }

        public void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbset.Attach(entityToDelete);
            }
            _dbset.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbset.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}

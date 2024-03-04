using Cinema.Data.Context;
using Cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
         where TEntity : MovieEntity
    {

        private readonly CinemaContext _db;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(CinemaContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();

            // _dbSet yerine _db.Users / _db.Products / _db.Categories gelecek.
        }

        public void Add(TEntity entity)
        {

            _dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;

            _dbSet.Update(entity);
            _db.SaveChanges();

        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate is null ? _dbSet : _dbSet.Where(predicate);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {

            _dbSet.Update(entity);
            _db.SaveChanges();
        }
    }
}

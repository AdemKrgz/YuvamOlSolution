using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YuvamOl.DAL.DbContexts;
using YuvamOl.DAL.Repositories.Abstracts.Core;

namespace YuvamOl.DAL.Repositories.Concretes.Core
{
        public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>, IDisposable where TEntity : class
        {
            YuvamOlDbContext _context;
            protected IDbSet<TEntity> _dbSet;
            public BaseRepository()
            {
                if (_context != null)
                {
                    Dispose();
                }
                _context = new YuvamOlDbContext();
                _dbSet = _context.Set<TEntity>();
            }

            public void Add(TEntity entity)
            {
                var entry = _context.Entry(entity);
                entry.State = EntityState.Added;
            try
            {

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                
                
                foreach (var item in ex.Message)
                {
                    Console.WriteLine(item);
                }
            }
                Dispose();
            }

            public void Delete(TKey key)
            {
                var entity = _dbSet.Find(key);
                var entry = _context.Entry(entity);
                entry.State = EntityState.Deleted;
                _context.SaveChanges();
                Dispose();
            }

            public void Dispose()
            {
                _context.Dispose();
            }

            public TEntity FindById(TKey key)
            {
                return _dbSet.Find(key);
            }

            public TEntity Find(Expression<Func<TEntity, bool>> lambda)
            {
                return _dbSet.Where(lambda).FirstOrDefault();
            }

            public void Update(TEntity entity)
            {
                var entry = _context.Entry(entity);
                entry.State = EntityState.Modified;
            try
            {

                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
                Dispose();
            }

        public IEnumerable<TEntity> WhereSelect(Expression<Func<TEntity, bool>> lambda = null)
        {
            return lambda == null ?
                _dbSet.AsEnumerable() :
                _dbSet.Where(lambda).AsEnumerable();
        }
    }
    }

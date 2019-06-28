using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace YuvamOl.DAL.Repositories.Abstracts.Core
{
    public interface IBaseRepository<TEntity, TKey>
    {
        void Add(TEntity entity);
        void Delete(TKey key);
        void Update(TEntity entity);
        TEntity FindById(TKey key);
        TEntity Find(Expression<Func<TEntity, bool>> lambda);

        IEnumerable<TEntity> WhereSelect(Expression<Func<TEntity, bool>> lambda = null);
    }
}

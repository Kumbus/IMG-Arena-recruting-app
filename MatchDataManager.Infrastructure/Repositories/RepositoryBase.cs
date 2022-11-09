using MatchDataManager.Domain.RepositoriesInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MatchDataManager.Infrastructure.Repositories;

    public  abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DatabaseContext DatabaseContext { get; set; }
        public RepositoryBase(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }
        public IQueryable<T> FindAll() => DatabaseContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            DatabaseContext.Set<T>().Where(expression).AsNoTracking();
        public void Add(T entity) => DatabaseContext.Set<T>().Add(entity);
        public void Update(T entity) => DatabaseContext.Set<T>().Update(entity);
        public void Delete(T entity) => DatabaseContext.Set<T>().Remove(entity);
    }


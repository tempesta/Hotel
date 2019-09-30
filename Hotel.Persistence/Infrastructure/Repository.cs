using Hotel.Application.Interface;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Hotel.Application.Interface.Infrastructure;

namespace Hotel.Persistence.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ISession _session;

        public Repository(UnitOfWork unitOfWork)
        {
            _session = unitOfWork.Session;
        }

        public void Create(TEntity entity)
        {
            _session.Save(entity);
        }

        public void Delete(TEntity entity)
        {
            _session.Delete(entity);
        }

        public TEntity Load(int id)
        {
            return _session.Load<TEntity>(id);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression != null ? _session.Query<TEntity>().Where(expression) : _session.Query<TEntity>();
        }

        public IQueryable<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression != null ?_session.Query<TEntity>().Where(expression) : _session.Query<TEntity>();
        }

        public void Update(TEntity entity)
        {
            _session.Update(entity);
        }
    }
}

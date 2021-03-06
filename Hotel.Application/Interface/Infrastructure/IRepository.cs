﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.Application.Interface.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Load(int id);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression = null);
        IQueryable<TEntity> Query<TEntity>(Expression<Func<TEntity, bool>> expression = null);
    }
}

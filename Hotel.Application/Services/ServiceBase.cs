using Hotel.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Services
{
    public class ServiceBase<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public IRepository<TEntity> Repository { get; set; }

        public ServiceBase(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Transaction(Action action)
        {
            _unitOfWork.BeginTransaction();

            try
            {
                action();
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Application.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}

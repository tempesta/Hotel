using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Hotel.Application.Interface;
using Microsoft.Extensions.Configuration;
using NHibernate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Hotel.Persistence.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; set; }

        static UnitOfWork()
        {
            var basePath = $"{Directory.GetCurrentDirectory()}/../Hotel.Api";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var entities = GetAssemblyByName("Hotel.Persistence");

            var fluent = Fluently.Configure()
                                    .Database(MySQLConfiguration.Standard.ConnectionString(connectionString).ShowSql())
                                    .Mappings(m => m.FluentMappings.AddFromAssembly(entities));

            _sessionFactory = fluent.BuildSessionFactory();
        }

        public UnitOfWork()
        {
            if (_sessionFactory != null)
                Session = _sessionFactory.OpenSession();
        }

        static Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == name);
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw ex;
            }
        }

        public void Rollback()
        {
            if (_transaction != null)
                _transaction.Rollback();
        }

        ~UnitOfWork ()
        {
            if(Session != null && Session.IsOpen)
            {
                Session.Dispose();
                Session.Close();
            }
        }
    }
}

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
using Hotel.Application.Interface.Infrastructure;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;

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

            var fluentConfiguration = Fluently.Configure()
                                    .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(connectionString).ShowSql())
                                    .Mappings(m => m.FluentMappings.AddFromAssembly(entities))
                                    .BuildConfiguration();

            var exporter = new SchemaExport(fluentConfiguration);
            exporter.Create(false, true);

            _sessionFactory = fluentConfiguration.BuildSessionFactory();

            Seeds();
        }

        static void Seeds()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var sql = $@"INSERT INTO comodidade (Id, Nome) VALUES (1, 'Estacionamento'),
                                                                      (2, 'Piscina'),
                                                                      (3, 'Sauna'),
                                                                      (4, 'Wi - fi'),
                                                                      (5, 'Restaurante'),
                                                                      (6, 'Bar')";

                session.CreateSQLQuery(sql).ExecuteUpdate();
            }
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

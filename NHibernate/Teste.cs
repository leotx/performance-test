using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;

namespace NHibernate
{
    public class Teste
    {
        private ISession Session { get; }
        private ITransaction Transaction { get; set; }

        public Teste()
        {
            CreateTable();

            var sessionFactory = Factory().BuildSessionFactory();
            Session = sessionFactory.OpenSession();

            InsertTest(10000);
            var allCliente = SelectAll();
            RemoveAll(allCliente);

            InsertTest(20000);
            allCliente = SelectAll();
            RemoveAll(allCliente);

            InsertTest(50000);
            allCliente = SelectAll();
            RemoveAll(allCliente);

            InsertTest(100000);
            allCliente = SelectAll();
            RemoveAll(allCliente);

            Console.WriteLine("Press [enter] to quit");
        }

        private static void CreateTable()
        {
            var fluentConfiguration = Factory().BuildConfiguration();
            var exportDatabase = new SchemaExport(fluentConfiguration);
            exportDatabase.Execute(true, true, false);
        }

        private static FluentConfiguration Factory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("defaultConnection")))
                .Mappings(val => val.AutoMappings.Add(AutoMap.AssemblyOf<Cliente>(new AutoMappingConfiguration()).Conventions
                .AddFromAssemblyOf<AutoMappingConfiguration>()
                .UseOverridesFromAssemblyOf<AutoMappingConfiguration>()));
        }

        private void InsertTest(int totalInsert)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Iniciando Insert de "+ totalInsert + " Registros");
            var datetimeBefore = DateTime.Now;

            Transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);

            for (var iC = 0; iC < totalInsert; iC++)
            {
                var cliente = Cliente.Create();

                Session.Save(cliente);
            }

            Transaction.Commit();

            var totalTime = DateTime.Now.Subtract(datetimeBefore).Seconds;
            Console.WriteLine("Tempo: " + totalTime + " segundos.");
        }

        private List<Cliente> SelectAll()
        {
            Console.WriteLine("Selecionando todo o conteúdo da tabela.");
            var datetimeBefore = DateTime.Now;

            var allCliente = Session.Query<Cliente>().ToList();

            var totalTime = DateTime.Now.Subtract(datetimeBefore).Seconds;
            Console.WriteLine("Tempo: " + totalTime + " segundos.");

            return allCliente;
        }

        private void RemoveAll(List<Cliente> allCliente)
        {
            Console.WriteLine("Limpando Tabela");
            var datetimeBefore = DateTime.Now;

            Transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);

            foreach (var entity in allCliente)
            {
                Session.Delete(entity);
            }

            Transaction.Commit();

            var totalTime = DateTime.Now.Subtract(datetimeBefore).Seconds;
            Console.WriteLine("Tempo: " + totalTime + " segundos.");
        }
    }
}
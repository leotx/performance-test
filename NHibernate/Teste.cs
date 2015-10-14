using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Linq;
using NHibernate.Test.Conventions;
using NHibernate.Test.Entities;
using NHibernate.Tool.hbm2ddl;

namespace NHibernate.Test
{
    public class Teste
    {
        private ISessionFactory SessionFactory { get; set; }

        public Teste()
        {
            CreateTable();

            SessionFactory = Factory().BuildSessionFactory();

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

            //InsertWithRelationship(1);
            //var allCliente = SelectAll();
            //RemoveAll(allCliente);

            Console.WriteLine("Press [enter] to quit");
        }

        private static void CreateTable()
        {
            var fluentConfiguration = Factory().BuildConfiguration();
            var exportDatabase = new SchemaExport(fluentConfiguration);
            exportDatabase.Execute(true, true, false);
        }

        private void InsertWithRelationship(int totalInsert)
        {
            using (var currentSession = SessionFactory.OpenSession())
            {
                using (var beginTransaction = currentSession.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    for (var iC = 0; iC < totalInsert; iC++)
                    {
                        var estado = Estado.Create();
                        currentSession.Save(estado);

                        var pais = Pais.Create();
                        currentSession.Save(pais);

                        var cidade = Cidade.Create();
                        currentSession.Save(cidade);

                        var endereco = Endereco.Create();
                        endereco.Estado = estado;
                        endereco.Pais = pais;
                        endereco.Cidade = cidade;
                        currentSession.Save(endereco);

                        var telefone = Telefone.Create();
                        currentSession.Save(telefone);

                        var cliente = Cliente.Create();
                        cliente.Enderecos.Add(endereco);
                        cliente.Telefones.Add(telefone);
                        currentSession.Save(cliente);
                    }

                    beginTransaction.Commit();
                }
            }
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
            Console.WriteLine("Iniciando insert de " + totalInsert + " registros");
            var stopWatcher = new Stopwatch();

            using (var currentSession = SessionFactory.OpenSession())
            {
                using (var beginTransaction = currentSession.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    stopWatcher.Start();

                    for (var iC = 0; iC < totalInsert; iC++)
                    {
                        var cliente = Cliente.Create();

                        currentSession.Save(cliente);
                    }

                    beginTransaction.Commit();

                    stopWatcher.Stop();

                    Console.WriteLine("Tempo total: " + stopWatcher.Elapsed);
                }
            }
        }

        private List<Cliente> SelectAll()
        {
            Console.WriteLine("Selecionando todo o conteúdo da tabela.");
            var stopWatcher = new Stopwatch();
            List<Cliente> allCliente;

            using (var currentSession = SessionFactory.OpenSession())
            {
                stopWatcher.Start();
                allCliente = currentSession.Query<Cliente>().ToList();
                stopWatcher.Stop();
            }

            Console.WriteLine("Tempo: " + stopWatcher.Elapsed);

            return allCliente;
        }

        private void RemoveAll(IEnumerable<Cliente> allCliente)
        {
            Console.WriteLine("Limpando Tabela");
            var stopWatcher = new Stopwatch();

            using (var currentSession = SessionFactory.OpenSession())
            {
                using (var beginTransaction = currentSession.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    stopWatcher.Start();

                    foreach (var entity in allCliente)
                    {
                        currentSession.Delete(entity);
                    }

                    beginTransaction.Commit();

                    stopWatcher.Stop();
                }
            }

            Console.WriteLine("Tempo: " + stopWatcher.Elapsed);
        }
    }
}
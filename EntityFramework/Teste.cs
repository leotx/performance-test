using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EntityFramework.Test
{
    public class Teste
    {
        private ClienteContext ClienteDb { get; set; }

        public Teste()
        {
            ClienteDb = new ClienteContext();
            ClienteDb.Configuration.AutoDetectChangesEnabled = false;
            ClienteDb.Configuration.ValidateOnSaveEnabled = false;
            ClienteDb.Database.Initialize(true);

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

        private void InsertTest(int totalInsert)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Iniciando insert de " + totalInsert + " registros");
            var stopWatcher = new Stopwatch();
            
            stopWatcher.Start();
            for (var iC = 0; iC < totalInsert; iC++)
            {
                var cliente = Cliente.Create();

                ClienteDb.Cliente.Add(cliente);
            }
            ClienteDb.SaveChanges();
            stopWatcher.Stop();

            Console.WriteLine("Tempo: " + stopWatcher.Elapsed);
        }

        private List<Cliente> SelectAll()
        {
            Console.WriteLine("Selecionando todo o conteúdo da tabela.");
            var stopWatcher = new Stopwatch();
            
            stopWatcher.Start();
            var allCliente = ClienteDb.Cliente.ToList();
            stopWatcher.Stop();

            Console.WriteLine("Tempo: " + stopWatcher.Elapsed);

            return allCliente;
        }

        private void RemoveAll(IEnumerable<Cliente> allCliente)
        {
            Console.WriteLine("Limpando Tabela");
            var stopWatcher = new Stopwatch();

            stopWatcher.Start();
            ClienteDb.Cliente.RemoveRange(allCliente);
            ClienteDb.SaveChanges();
            stopWatcher.Stop();

            Console.WriteLine("Tempo: " + stopWatcher.Elapsed);
        }
    }
}
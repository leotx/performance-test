using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework
{
    public class Teste
    {
        private ClienteContext ClienteDb { get; set; }

        public Teste()
        {
            ClienteDb = new ClienteContext();
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
            Console.WriteLine("Iniciando Insert de " + totalInsert + " Registros");
            var datetimeBefore = DateTime.Now;

            for (var iC = 0; iC < totalInsert; iC++)
            {
                var cliente = Cliente.Create();

                ClienteDb.Cliente.Add(cliente);
            }

            ClienteDb.SaveChanges();

            var totalTime = DateTime.Now.Subtract(datetimeBefore).Seconds;
            Console.WriteLine("Tempo: " + totalTime + " segundos.");
        }

        private List<Cliente> SelectAll()
        {
            Console.WriteLine("Selecionando todo o conteúdo da tabela.");
            var datetimeBefore = DateTime.Now;

            var allCliente = ClienteDb.Cliente.ToList();

            var totalTime = DateTime.Now.Subtract(datetimeBefore).Seconds;
            Console.WriteLine("Tempo: " + totalTime + " segundos.");

            return allCliente;
        }

        private void RemoveAll(List<Cliente> allCliente)
        {
            Console.WriteLine("Limpando Tabela");
            var datetimeBefore = DateTime.Now;

            ClienteDb.Cliente.RemoveRange(allCliente);
            ClienteDb.SaveChanges();

            var totalTime = DateTime.Now.Subtract(datetimeBefore).Seconds;
            Console.WriteLine("Tempo: " + totalTime + " segundos.");
        }
    }
}
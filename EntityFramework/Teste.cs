using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework
{
    public class Teste
    {
        public Teste()
        {
            using (var db = new ClienteContext())
            {
                db.Database.EnsureCreated();
            }

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

            using (var db = new ClienteContext())
            {
                for (var iC = 0; iC < totalInsert; iC++)
                {
                    var cliente = Cliente.Create();

                    db.Cliente.Add(cliente);
                }

                db.SaveChanges();
            }

            var totalTime = DateTime.Now.Subtract(datetimeBefore).Seconds;
            Console.WriteLine("Tempo: " + totalTime + " segundos.");
        }

        private List<Cliente> SelectAll()
        {
            Console.WriteLine("Selecionando todo o conteúdo da tabela.");
            var datetimeBefore = DateTime.Now;

            List<Cliente> allCliente;

            using (var db = new ClienteContext())
            {
                allCliente = db.Cliente.ToList();
            }

            var totalTime = DateTime.Now.Subtract(datetimeBefore).Seconds;
            Console.WriteLine("Tempo: " + totalTime + " segundos.");

            return allCliente;
        }

        private void RemoveAll(List<Cliente> allCliente)
        {
            Console.WriteLine("Limpando Tabela");
            var datetimeBefore = DateTime.Now;

            using (var db = new ClienteContext())
            {
                db.Cliente.RemoveRange(allCliente);
                db.SaveChanges();
            }

            var totalTime = DateTime.Now.Subtract(datetimeBefore).Seconds;
            Console.WriteLine("Tempo: " + totalTime + " segundos.");
        }
    }
}
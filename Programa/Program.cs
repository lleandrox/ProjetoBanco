using System;
using System.Collections.Generic;
using System.Text;

namespace Programa
{
     class Program
    {
        private static readonly Banco banco = new Banco();
        private static readonly Conta contaDestino;

        static Program()
        {
            var cidade = new Cidade("jundiai", "SP");

            var endereco = new Endereco("Rua gen osorio", "centro", "12345-123", 100, cidade);

            var cliente = new Cliente("Grilo", "123456", new DateTime(2000, 7, 2), endereco);

            contaDestino = banco.AbrirConta(cliente);

        }
        public static void Main(string[] args)
        {
            try
            {
                var cidade = new Cidade("jundiai", "SP");

                var endereco = new Endereco("Rua gen osorio", "centro", "12345-123", 100, cidade);

                var cliente = new Cliente("Grilo", "123456", new DateTime(2000, 7, 2), endereco);

                var contaRicardo = banco.AbrirConta(cliente);

                contaRicardo.Depositar(2500);

                contaRicardo.Sacar(350);

                contaRicardo.TirarExtrato();

                contaRicardo.Transferir(1, 1, 12000);

                contaRicardo.TirarExtrato();

                contaDestino.TirarExtrato();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ResetColor();
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine("aperte uma tecla para sair");
            Console.ReadLine();
        }
    }
}

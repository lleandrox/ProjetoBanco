using Programa.Enums;
using Programa.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Programa
{
    internal class Conta
    {
        public TipoConta TipoConta { get;  private set; }
        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public decimal Saldo { get; private set; }
        public Banco Banco { get; private set; }

        public List<Transacao> Transacoes { get; private set; }

        public Conta(TipoConta tipoConta, int agencia, int numero, Banco banco)
        {
            TipoConta = tipoConta;
            Agencia = agencia;
            Numero = numero;
            Banco = banco;
            //Transacoes = new List<Transacao>();
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
            throw new Exception("o valor solicitado é invalido.");
            if (valor > Saldo)
                throw new Exception("Saldo insulficiente para realizar o saque,");

            Debitar("retirada", valor);
            Console.WriteLine("Saque realizado com sucesso,");   
        }


         public void Depositar(decimal valor)
         {
            if (valor <= 0)
                throw new Exception("o valor é invalido,");

            Creditar("deposito", valor);
            Console.WriteLine("deposito realizado com sucesso,");

        }


        public void Transferir(int agencia, int numeroConta, decimal valor)
        {
            if (valor <= 0)
                throw new Exception("o valor é invalido");
            if (valor > Saldo)
                throw new Exception("saldo insulficiente para realizar a transferencia");

            var contaDestino = Banco.ObterConta(agencia, numeroConta);

            contaDestino.Creditar("transferência", valor);
            Debitar("Transferencia", valor);

            Console.WriteLine("transferência realizada com sucesso");
        }
        public void TirarExtrato()
        {
            //Transacoes.any()
            if(Transacoes.Count > 0)
            {
                foreach (var transacao in Transacoes)
                {
                    var cor = transacao.TipoTransacao == TipoTransacao.Debito ? ConsoleColor.Red : ConsoleColor.Green;
                    Console.ForegroundColor = cor;
                    var descricao = transacao.Descricao.PadRight(20, '-') + transacao.Valor.ToString("C");
                    Console.WriteLine(descricao);
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(string.Empty);
                var saldodescricao = "Saldo".PadRight(20, '-') + Saldo.ToString("C");
                Console.WriteLine(saldodescricao);
            }
        }

        private void Creditar(string descricao, decimal valor)
        {
            var transacao = new Transacao(descricao, valor, TipoTransacao.Credito);
            Transacoes.Add(transacao);
            Saldo += valor;
        }


        private void Debitar(string descricao, decimal valor)
        {
            var transacao = new Transacao(descricao, valor, TipoTransacao.Debito);
            Transacoes.Add(transacao);
            Saldo -= valor;
        }

        
    }
}

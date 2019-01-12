﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Programa
{
    internal class Banco
    {
        public string Nome { get; private set; }
        public short Numero { get; private set; }
        //public Endereco  Endereco { get; private set; }
        public List<Conta> Contas { get; private set; }


        public Banco()
        {
            Contas = new List<Conta>();
        }
        public Conta AbrirConta(Cliente Cliente)
        {
            if (!Cliente.MaiorDeIdade())
                throw new Exception("Apenas pessoas maiores de 18 anos podem abrir conta");
            var numeroConta = Contas.Count + 1;

            var conta = new Conta(Enuns.TipoConta.Corrente, 1, numeroConta, this);

            Contas.Add(conta);
            return conta;
        }
        
        public Conta ObterConta(int agencia, int numeroConta )
        {
            var conta = Contas.FirstOrDefault(c => c.Agencia == agencia && c.Numero == numeroConta);

            if (conta == null)
                throw new Exception("Conta não encontrada");
            return conta;
            
        }
        public void FecharConta(Conta conta)
        {
            Contas.Remove(conta);
        }
    }
}

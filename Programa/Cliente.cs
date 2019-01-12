using System;
using System.Collections.Generic;
using System.Text;

namespace Programa
{
    internal class Cliente
    {
        public string  Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public Endereco Endereco { get; private set; }

        public Cliente(string nome, string cpf, DateTime dataDeNasimento, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            DataDeNascimento = dataDeNasimento;
            Endereco = endereco;

        }
        public bool MaiorDeIdade()
        {
            var nascimentoMinimo = DateTime.Now.AddYears(-18);
            return DataDeNascimento <= nascimentoMinimo;
        }
    }
}

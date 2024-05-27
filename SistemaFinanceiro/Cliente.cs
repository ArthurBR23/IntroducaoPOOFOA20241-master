using SistemaFinanceiro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinanceiro
{
    public class Cliente
    {
        private string _nome, _cpf;
        private int _anoNascimento;

        public Cliente(string nome, string cpf, int anoNascimento)
        {
            _nome = nome;
            _cpf = cpf;
            _anoNascimento = anoNascimento;

            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome inválido");
            }
            else if (string.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("CPF inválido");
            }
            
        }
      
        public string Nome
        {
            get => _nome;
            private set
            {
                _nome = value;
            }
        }

        public string CPF
        {
            get => _cpf;
            private set
            {
                _cpf = value;
            }
        }

        public int AnoNascimento
        {
            get => _anoNascimento;
        }
    }

}

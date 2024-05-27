using SistemaFinanceiro.Model;
using SistemaFinanceiro;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Conta> contas = new List<Conta>();

        while (true)
        {
            Console.WriteLine("\nMENU INICIAL");
            Console.WriteLine("1. Criar cliente e conta");
            Console.WriteLine("2. Acessar menu de operações");
            Console.WriteLine("3. Sair");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarClienteEConta(contas);
                    break;
                case "2":
                    if (contas.Count < 2)
                    {
                        Console.WriteLine("Crie pelo menos duas contas para acessar o menu de operações.");
                        break;
                    }
                    AcessarMenuOperacoes(contas);
                    break;
                case "3":
                    Console.WriteLine("Saindo do programa...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CriarClienteEConta(List<Conta> contas)
    {
        Cliente cliente = CriarCliente();
        Conta conta = CriarConta(cliente);
        contas.Add(conta);
        Console.WriteLine("Cliente e conta criados com sucesso!");
    }

    static Cliente CriarCliente()
    {
        Console.WriteLine("\nCRIAÇÃO DE CLIENTE");
        Console.Write("Nome do cliente: ");
        string nome = Console.ReadLine();
        Console.Write("CPF do cliente: ");
        string cpf = Console.ReadLine();
        Console.Write("Ano de nascimento do cliente: ");
        int anoNascimento = int.Parse(Console.ReadLine());
        return new Cliente(nome, cpf, anoNascimento);
    }

    static Conta CriarConta(Cliente cliente)
    {
        Console.WriteLine("\nCRIAÇÃO DE CONTA");
        Console.Write("Número da conta: ");
        long numeroConta = long.Parse(Console.ReadLine());
        Console.Write("Saldo inicial da conta: ");
        decimal saldoInicial = decimal.Parse(Console.ReadLine());
        return new Conta(numeroConta, saldoInicial, cliente);
    }

    static void AcessarMenuOperacoes(List<Conta> contas)
    {
        Conta conta1 = contas[0];
        Conta conta2 = contas[1];

        while (true)
        {
            Console.WriteLine("\nMENU DE OPERAÇÕES");
            Console.WriteLine("1. Depósito");
            Console.WriteLine("2. Saque");
            Console.WriteLine("3. Transferência");
            Console.WriteLine("4. Voltar ao menu inicial");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Informe o valor do depósito: ");
                    decimal valorDeposito = decimal.Parse(Console.ReadLine());
                    conta1.Deposito(valorDeposito);
                    Console.WriteLine($"Depósito de R${valorDeposito} realizado com sucesso. Novo saldo: R${conta1.Saldo}");
                    break;
                case "2":
                    Console.Write("Informe o valor do saque: ");
                    decimal valorSaque = decimal.Parse(Console.ReadLine());
                    try
                    {
                        conta1.Saque(valorSaque);
                        Console.WriteLine($"Saque de R${valorSaque} realizado com sucesso. Novo saldo: R${conta1.Saldo}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "3":
                    Console.Write("Informe o valor da transferência: ");
                    decimal valorTransferencia = decimal.Parse(Console.ReadLine());
                    try
                    {
                        conta1.Transferencia(valorTransferencia, conta2);
                        Console.WriteLine($"Transferência de R${valorTransferencia} para {conta2.Titular.Nome} realizada com sucesso.");
                        Console.WriteLine($"Saldo do(a) {conta1.Titular.Nome}: R${conta1.Saldo}");
                        Console.WriteLine($"Saldo do(a) {conta2.Titular.Nome}: R${conta2.Saldo}");

                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}

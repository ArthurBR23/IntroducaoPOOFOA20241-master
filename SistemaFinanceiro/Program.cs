// See https://aka.ms/new-console-template for more information
using SistemaFinanceiro;
using SistemaFinanceiro.Model;

var cliente1 = new Cliente("", "12345678900", 2003);
Console.WriteLine($"Cliente: {cliente1.Nome}, CPF: {cliente1.CPF}, Ano de Nascimento: {cliente1.AnoNascimento}");

var conta1 = new Conta(123, 11);
Console.WriteLine($"Conta: {conta1.Numero}, Saldo: {conta1.Saldo}");
//conta1.Numero = 321;


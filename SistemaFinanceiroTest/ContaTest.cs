using SistemaFinanceiro;
using SistemaFinanceiro.Model;

namespace SistemaFinanceiroTest
{
    [TestClass]
    public class ContaTest
    {
        [TestMethod]
        public void DepositoTest()
        {
            //cenario
            decimal saldoInicial = 1000;
            decimal valorDeposito = 1000;
            decimal saldoFinal = 2000;
            Cliente cliente1 = new Cliente("Arthur", "12345678900", 2003);
            Conta conta1 = new Conta(123, saldoInicial, cliente1);

            //ação
            conta1.Deposito(valorDeposito);

            //verificação
            Assert.AreEqual(saldoFinal, conta1.Saldo);
        }

        [TestMethod]
        public void SaqueTest()
        {
            //cenario
            decimal saldoInicial = 1000;
            decimal valorSaque = 500;
            decimal saldoFinal = 499.90m;
            Cliente cliente1 = new Cliente("Arthur", "12345678900", 2003);
            Conta conta1 = new Conta(123, saldoInicial, cliente1);

            //ação
            conta1.Saque(valorSaque);

            //verificação
            Assert.AreEqual(saldoFinal, conta1.Saldo);
        }

        [TestMethod]
        public void ValorSaqueMaiorSaldo()
        {
            //cenario
            decimal saldoInicial = 1000;
            decimal valorSaque = 1500;
            Cliente cliente1 = new Cliente("Arthur", "12345678900", 2003);
            Conta conta1 = new Conta(123, saldoInicial, cliente1);

            //verificação
            Assert.ThrowsException<ArgumentException>(() => conta1.Saque(valorSaque));
        }

        [TestMethod]

        public void TransferenciaTest()
        {
            // cenario
            Cliente cliente1 = new Cliente("Arthur", "12345678900", 2003);
            Cliente cliente2 = new Cliente("Kamanda", "98765432100", 2001);
            Conta conta1 = new Conta(123, 200, cliente1);
            Conta conta2 = new Conta(456, 100, cliente2);
            decimal valorTransferencia = 50;

            // Ação
            conta1.Transferencia(valorTransferencia, conta2);

            // Verificação
            Assert.AreEqual(150, conta1.Saldo);
            Assert.AreEqual(150, conta2.Saldo);
        }
    }
}
using System;
using TransferenciaBancaria.Enums;

namespace TransferenciaBancaria.Classes
{
    public class Conta
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(string nome, double saldo, double credito, TipoConta tipoConta)
        {
            Nome = nome;
            Saldo = saldo;
            Credito = credito;
            TipoConta = tipoConta;
        }

        public bool Sacar(double saque)
        {
            if (Saldo - saque < (Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            else
            {
                Saldo -= saque;

                Console.WriteLine("O saldo da conta {0} é: R$ {1} ", Nome, Saldo);
                return true;
            }
        }
         
        public void Depositar(double deposito)
        {
            Saldo += deposito;

            Console.WriteLine("O saldo da conta {0} é: R$ {1} ", Nome, Saldo);
        }
        
        public void Transferir(double transferencia, Conta contaDestino)
        {
            if (Sacar(transferencia))          
                contaDestino.Depositar(transferencia);            
        }

        public override string ToString()
        {
            string retorno = " ";
            retorno += "Tipo: " + TipoConta + " - ";
            retorno += "Nome: " + Nome + " - ";
            retorno += "Saldo: R$ " + Saldo + " - ";
            retorno += "Crédito: R$ " + Credito;

            return retorno;
        }
    }
}

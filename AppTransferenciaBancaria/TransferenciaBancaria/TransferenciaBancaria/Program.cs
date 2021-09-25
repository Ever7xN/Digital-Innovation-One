using System;
using System.Collections.Generic;
using TransferenciaBancaria.Classes;

namespace TransferenciaBancaria
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUser = ObterOpcaoUser();

            while (opcaoUser.ToUpper() != "X")
            {
                switch(opcaoUser)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Transferir();
                        break;

                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUser = ObterOpcaoUser();
            }
            Console.WriteLine("Obrigado pela preferência");
            Console.ReadLine();
        }       
        private static string ObterOpcaoUser()
        {
            Console.WriteLine();
            Console.WriteLine("Bank DIO Bem vindo!");
            Console.WriteLine("Selecione a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir conta");
            Console.WriteLine("3 - Transferência entre contas");
            Console.WriteLine("4 - Efetuar saque");
            Console.WriteLine("5 - Realizar deposito");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUser;
        }
        private static void ListarContas()
        {
            Console.WriteLine("Lista de contas:");
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            else
            {
                for (int i = 0; i < listaContas.Count; i++)
                {
                    Conta conta = listaContas[i];
                    Console.WriteLine("#{0} - {1}", i, conta );                    
                }
            }
            Console.WriteLine();
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir conta:");
            Console.Write("Informe o nome: ");
            string nome = Console.ReadLine();
            Console.Write("Informe o saldo da conta: ");
            double saldo = double.Parse(Console.ReadLine());
            Console.Write("Informe o crédito da conta: ");
            double credito = double.Parse(Console.ReadLine());
            Console.Write("Informe o tipo da conta: (1 - Pessoa Fisica), (2 - Pessoa Júridica): ");
            int tipoConta = int.Parse(Console.ReadLine());

            Conta novaConta = new Conta(nome, saldo, credito, (Enums.TipoConta)tipoConta);
            listaContas.Add(novaConta);
        }
        public static void Sacar()
        {
            Console.Write("Informe o numero da conta: ");
            int numConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[numConta].Sacar(valorSaque);
        }
        public static void Depositar()
        {
            Console.Write("Informe o numero da conta: ");
            int numConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[numConta].Depositar(valorDeposito);
        }
        public static void Transferir()
        {
            Console.Write("Informe o numero da conta origem: ");
            int numConta = int.Parse(Console.ReadLine());
            Console.Write("Informe o numero da conta destino: ");
            int numContaDes = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser trânsferido: ");
            double valorTransf = double.Parse(Console.ReadLine());

            listaContas[numConta].Transferir(valorTransf, listaContas[numContaDes]);
        }
    }
}

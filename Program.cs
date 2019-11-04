using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio24 {
   
   
    class Program {
        

            
        static List<Conta> contas = new List<Conta> ();

        static Int32 LerInteiroPositivo () {
            Int32 numeroLido = 0;
            Boolean lerNumero = true;
            Boolean numeroValido = true;

            while (lerNumero == true) {
                try {
                    numeroLido = Convert.ToInt32 (Console.ReadLine ());
                    numeroValido = true;
                } catch (Exception ex) {
                    Console.WriteLine ("Valor inválido, favor informar somente números inteiros positivos");
                    numeroValido = false;
                }

                if (numeroValido == true) {
                    if (numeroLido > 0) {
                        lerNumero = false;
                    } else {
                        Console.WriteLine ("Número inválido, favor informar somente números inteiros positivos");
                    }
                }
            }

            return numeroLido;
        }

        static Double LerRealPositivo () {
            Int32 numeroLido = 0;
            Boolean lerNumero = true;
            Boolean numeroValido = true;

            while (lerNumero == true) {
                try {
                    numeroLido = Convert.ToInt32 (Console.ReadLine ());
                    numeroValido = true;
                } catch (Exception ex) {
                    Console.WriteLine ("Valor inválido, favor informar somente números reais positivos");
                    numeroValido = false;
                }

                if (numeroValido == true) {
                    if (numeroLido > 0) {
                        lerNumero = false;
                    } else {
                        Console.WriteLine ("Número inválido, favor informar somente números reais positivos");
                    }
                }
            }

            return numeroLido;
        }

        static Double LertaxaPositiva () {
            Int32 numeroLido = 0;
            Boolean lerNumero = true;
            Boolean numeroValido = true;

            while (lerNumero == true) {
                try {
                    numeroLido = Convert.ToInt32 (Console.ReadLine ());
                    numeroValido = true;
                } catch (Exception ex) {
                    Console.WriteLine ("Valor inválido, favor informar somente números reais positivos");
                    numeroValido = false;
                }

                if (numeroValido == true) {
                    if (numeroLido > 0 && numeroLido <= 5) {
                        lerNumero = false;
                    } else {
                        Console.WriteLine ("Número inválido, favor informar somente números reais positivos e menores que 5");
                    }
                }
            }

            return numeroLido;
        }

        static void MontarMenu (String[] opcoes, Action[] acoes) {
            if (opcoes.Length > 0) {
                Boolean imprimirMenu = true;
                StringBuilder menu = new StringBuilder ();
                Int32 numeroOpcao = 1;

                menu.Append (numeroOpcao).Append (" - ").Append (opcoes[numeroOpcao - 1]);

                for (numeroOpcao = 2; numeroOpcao <= opcoes.Length; numeroOpcao++) {
                    menu.Append ("\n").Append (numeroOpcao).Append (" - ").Append (opcoes[numeroOpcao - 1]);
                }

                while (imprimirMenu == true) {
                    Console.WriteLine (menu.ToString ());
                    Int32 opcaoEscolhida = LerInteiroPositivo ();

                    if (opcaoEscolhida < opcoes.Length) {
                        acoes[opcaoEscolhida - 1] ();
                    } else if (opcaoEscolhida == opcoes.Length) {
                        imprimirMenu = false;
                    } else {
                        Console.WriteLine ("Opção inválida");
                    }
                }
            }
        }

        static void AbrirContaPoupanca () {
            Console.WriteLine ("Informe o número da conta:");
            Int32 numero = LerInteiroPositivo ();

            ContaPoupanca contaCadastro = new ContaPoupanca (numero);

            if (contas.Contains (contaCadastro) == true) {
                Console.WriteLine ("Conta já cadastrada");
            } else {
                contas.Add (contaCadastro);

                Console.WriteLine ("Conta cadastrada com sucesso");
            }
        }

        static void AbrirContaCorrente () {
            Console.WriteLine ("Informe o número da conta:");
            Int32 numero = LerInteiroPositivo ();

            ContaCorrente contaCadastrado = new ContaCorrente (numero);

            if (contas.Contains (contaCadastrado) == true) {
                Console.WriteLine ("Conta já cadastrada");
            } else {
                Console.WriteLine ("Informe o limite da conta:");
                Double limite = LerRealPositivo ();

                contaCadastrado.GravarLimite (limite);

                contas.Add (contaCadastrado);

                Console.WriteLine ("Conta cadastrada com sucesso");
            }
        }

        static void Depositar () {
            Console.WriteLine ("Informe o número da conta:");
            Int32 numero = LerInteiroPositivo ();

            Conta contaDeposito = new Conta (numero);
            Int32 posicao = contas.IndexOf (contaDeposito);

            if (posicao >= 0) {
                Console.WriteLine ("Informe o valor:");
                Double valor = LerRealPositivo ();

                contaDeposito = contas[posicao];

                contaDeposito.Depositar (valor);

                Console.WriteLine ("Depósito realizado com sucesso");
            } else {
                Console.WriteLine ("Conta não encontrada");
            }
        }

        static void Sacar () {
            Console.WriteLine ("Informe o número da conta:");
            Int32 numero = LerInteiroPositivo ();

            Conta contaSaque = new Conta (numero);
            Int32 posicao = contas.IndexOf (contaSaque);

            if (posicao >= 0) {
                Console.WriteLine ("Informe o valor:");
                Double valor = LerRealPositivo ();

                contaSaque = contas[posicao];

                if (contaSaque.Sacar (valor) == true) {
                    Console.WriteLine ("Saque realizado com sucesso");
                } else {
                    Console.WriteLine ("Saldo insuficiente");
                }
            } else {
                Console.WriteLine ("Conta não encontrada");
            }
        }

        static void ConsultarSaldo () {
            Console.WriteLine ("Informe o número da conta:");
            Int32 numero = LerInteiroPositivo ();

            Conta contaSaldo = new Conta (numero);
            Int32 posicao = contas.IndexOf (contaSaldo);

            if (posicao >= 0) {
                contaSaldo = contas[posicao];

                Console.WriteLine ("{0:c}", contaSaldo.ObterSaldo ());
            } else {
                Console.WriteLine ("Conta não encontrada");
            }
        }

        static void ConsultarLimite () {
            Console.WriteLine ("Informe o número da conta:");
            Int32 numero = LerInteiroPositivo ();

            Conta contaLimite = new Conta (numero);
            Int32 posicao = contas.IndexOf (contaLimite);

            if (posicao >= 0) {
                contaLimite = contas[posicao];

                if (contaLimite is ContaCorrente) {
                    Console.WriteLine ("{0:c}", ((ContaCorrente) contaLimite).ObterLimite ());
                } else {
                    Console.WriteLine ("Conta não encontrada");
                }
            } else {
                Console.WriteLine ("Conta não encontrada");
            }
        }

        static void consultaextrato () {
            Console.WriteLine ("a");
        }

        static void calcularrendimento (){
            Console.WriteLine ("c");
        }

        static void Main (string[] args) {
            MontarMenu (new String[] {
                "Abrir Conta Poupança",
                "Abrir Conta Corrente",
                "Depositar",
                "Sacar",
                "Consultar Saldo",
                "consulta extrato",
                "Consultar Limite",
                "calcular rendimento",
                "Sair"
            }, new Action[] {
                AbrirContaPoupanca,
                AbrirContaCorrente,
                Depositar,
                Sacar,
                ConsultarSaldo,
                consultaextrato,
                ConsultarLimite,
                calcularrendimento
            });
        }
    }
}
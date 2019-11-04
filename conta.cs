using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio24
{
	public class Conta
    {
       
        static List<transacao> transacao = new List<transacao> ();


		private Int32 Numero { set; get; }
		private Double Saldo { set; get; }

		public Conta(Int32 numero)
		{
			this.Numero = numero;
		}

		protected virtual Boolean PodeSacar(Double valor)
		{
			if (this.Saldo - valor >= 0)
			{
				return true;
			}

			return false;
		}

		public override bool Equals(Object obj)
		{
			return this.Numero == ((Conta)obj).Numero;
		}

		public void Depositar(Double valor)
		{
			this.Saldo = this.Saldo + valor;
		}

		public Boolean Sacar(Double valor)
		{
			if (this.PodeSacar(valor) == true)
			{
				this.Saldo = this.Saldo - valor;
				return true;
			}

			return false;
		}

		public Double ObterSaldo()
		{
			return this.Saldo;
		}
	}
}

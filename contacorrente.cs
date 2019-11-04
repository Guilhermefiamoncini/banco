using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio24
{
	public class ContaCorrente : Conta
	{
		private Double Limite { set; get; }

		public ContaCorrente(Int32 numero) : base(numero)
		{

		}

		protected override bool PodeSacar(double valor)
		{
			if ((this.ObterSaldo() + this.Limite) - valor >= 0)
			{
				return true;
			}

			return false;
		}

		public void GravarLimite(Double limite)
		{
			this.Limite = limite;
		}

		public Double ObterLimite()
		{
			return this.Limite;
		}
	}
}

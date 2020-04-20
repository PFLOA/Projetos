using System;
using OpenQA.Selenium.PhantomJS;

namespace GetInfoCnpjReceita
{
    public class CnpjValidador
    {
		private string _cnpj;

		public string Cnpj
		{
			get { return _cnpj; }
			set { _cnpj = value; }
		}


	}
}

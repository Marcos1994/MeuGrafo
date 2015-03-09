using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrafoWebService.NS_GrafoDTO
{
	public class GrafoWSErro : Retorno
	{
		public string mensagem { get; set; }

		public GrafoWSErro()
		{
			this.retorno = "NAK";
			this.mensagem = "";
		}

		public GrafoWSErro(Exception ex)
		{
			this.retorno = "NAK";
			this.mensagem = ex.Message;
		}
	}
}
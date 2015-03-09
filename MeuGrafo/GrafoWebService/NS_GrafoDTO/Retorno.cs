using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrafoWebService.NS_GrafoDTO
{
	public class Retorno
	{
		public string retorno { get; set; }

		public Retorno()
		{
			this.retorno = "ACK";
		}
	}
}
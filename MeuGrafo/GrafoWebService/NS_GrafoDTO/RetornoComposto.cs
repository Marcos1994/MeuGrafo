using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrafoWebService.NS_GrafoDTO
{
	public class RetornoComposto : Retorno
	{
		public Object objeto { get; set; }

		public RetornoComposto(Object obj)
		{
			this.retorno = "ACK";
			objeto = obj;
		}
	}
}
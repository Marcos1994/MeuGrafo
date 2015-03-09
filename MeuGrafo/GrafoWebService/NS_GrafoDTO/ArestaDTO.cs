using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrafoWebService.NS_GrafoDTO
{
	public class ArestaDTO
	{
		public int peso { get; set; }
		public int idAresta { get; set; }
		public int idOrigem { get; set; }
		public int idDestino { get; set; }
	}
}
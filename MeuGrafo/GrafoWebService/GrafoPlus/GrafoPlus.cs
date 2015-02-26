using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeuGrafo;

namespace GrafoWebService.GrafoPlus
{
	public class GrafoPlus : Grafo
	{
		public int idGrafo { get; set; }
		public string nome { get; set; }
		public int width { get; set; }
		public int height { get; set; }
	}
}
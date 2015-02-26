using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeuGrafo;

namespace GrafoWebService.GrafoPlus
{
	public class VerticePlus : Vertice
	{
		public int idVertice { get; set; }
		public int posX { get; set; }
		public int posY { get; set; }
	}
}
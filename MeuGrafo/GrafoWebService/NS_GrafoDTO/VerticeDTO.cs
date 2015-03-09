using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrafoWebService.NS_GrafoDTO
{
	public class VerticeDTO
	{
		public int idVertice { get; set; }
		public string valor { get; set; }
		public int posX { get; set; }
		public int posY { get; set; }
		public int cor { get; set; }
	}
}
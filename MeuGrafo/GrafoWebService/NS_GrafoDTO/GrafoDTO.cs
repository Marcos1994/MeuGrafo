using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrafoWebService.NS_GrafoDTO
{
	public class GrafoDTO
	{
		public int idGrafo { get; set; }
		public string nome { get; set; }
		public List<VerticeDTO> vertices { get; set; }
		public List<ArestaDTO> arestas { get; set; }
		public int width { get; set; }
		public int height { get; set; }

		public GrafoDTO()
		{
			vertices = new List<VerticeDTO>;
			arestas = new List<ArestaDTO>;
		}
	}
}
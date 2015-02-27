using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrafoSimples;

namespace GrafoWebService.NS_GrafoPlus
{
	public class ArestaPlus : Aresta
	{
		public int idAresta { get; set; }
		public int idOrigem { get; set; }
		public int idDestino { get; set; }

		public ArestaPlus(int peso, int idAresta, int idOrigem, int idDestino)
		{
			this.peso = peso;
			this.idAresta = idAresta;
			this.idOrigem = idOrigem;
			this.idDestino = idDestino;
		}

		public ArestaPlus(VerticePlus origem, VerticePlus destino, int peso, int idAresta)
			: base(origem, destino, peso)
		{
			this.idAresta = idAresta;
			this.idOrigem = origem.idVertice;
			this.idDestino = destino.idVertice;
		}
	}
}
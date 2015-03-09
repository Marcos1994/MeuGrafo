using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrafoSimples;
using GrafoWebService.NS_GrafoDAO;
using GrafoWebService.NS_GrafoDTO;

namespace GrafoWebService.NS_GrafoPlus
{
	public class ArestaPlus : Aresta
	{
		public int idAresta { get; set; }
		public int idOrigem { get; set; }
		public int idDestino { get; set; }

		public ArestaPlus(int idOrigem, int idDestino, int peso = 1)
		{
			this.peso = peso;
			this.idAresta = idAresta;
			this.idOrigem = idOrigem;
			this.idDestino = idDestino;
		}

		public ArestaPlus(int idAresta, int idOrigem, int idDestino, int peso = 1)
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

		public ArestaDTO gerarDTO()
		{
			ArestaDTO aresta = new ArestaDTO();
			aresta.idAresta = this.idAresta;
			aresta.idOrigem = this.idOrigem;
			aresta.idDestino = this.idDestino;
			aresta.peso = this.peso;
			return aresta;
		}

		public void criarAresta()
		{
			try
			{
				ArestaDAO dao = new ArestaDAO()
				dao.criarAresta(this.idOrigem, this.idDestino, this.peso);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
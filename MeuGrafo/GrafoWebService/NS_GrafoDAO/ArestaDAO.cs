using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrafoWebService.NS_GrafoDAO
{
	public class ArestaDAO
	{
		internal void criarAresta(int idOrigem, int idDestino, int peso)
		{
			try
			{
				GrafoLinqDataContext dt = new GrafoLinqDataContext();
				tb_Aresta novaAresta = new tb_Aresta();
				novaAresta.id_origem = idOrigem;
				novaAresta.id_destino = idDestino;
				novaAresta.peso = peso;
				dt.tb_Arestas.InsertOnSubmit(novaAresta);
				dt.SubmitChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
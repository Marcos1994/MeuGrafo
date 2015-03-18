using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrafoWebService;
using GrafoWebService.NS_GrafoPlus;

namespace GrafoWebService.NS_GrafoDAO
{
	public class GrafoDAO
	{
		public void criarGrafo(string nome, int width, int height)
		{
			GrafoLinqDataContext dt = new GrafoLinqDataContext();
			tb_Grafo novoGrafo = new tb_Grafo();
			novoGrafo.nome = nome;
			novoGrafo.width = width;
			novoGrafo.height = height;
			dt.tb_Grafos.InsertOnSubmit(novoGrafo);
			try
			{
				dt.SubmitChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public GrafoPlus abrirGrafo(string nome)
		{
			GrafoLinqDataContext dt = new GrafoLinqDataContext();
			try
			{
				tb_Grafo grafoAberto = dt.tb_Grafos.First(g => g.nome == nome);
				GrafoPlus grafo = new GrafoPlus(nome);
				grafo.width = grafoAberto.width;
				grafo.height = grafoAberto.height;
				grafo.idGrafo = grafoAberto.id_grafo;
				foreach (tb_Vertice vertice in grafoAberto.tb_Vertices)
					grafo.inserirVertice(vertice.nome, vertice.posX, vertice.posY, vertice.id_vertice);

				var arestasDoGrafo = from a in dt.tb_Arestas where a.tb_Vertice.tb_Grafo.nome == nome select a;
				VerticePlus origem, destino;
				foreach (tb_Aresta aresta in arestasDoGrafo)
				{
					origem = ((VerticePlus)grafo.vertices.Find(o => ((VerticePlus)o).idVertice == aresta.id_origem));
					destino = ((VerticePlus)grafo.vertices.Find(d => ((VerticePlus)d).idVertice == aresta.id_destino));
					grafo.inserirAresta(origem, destino, aresta.peso, aresta.id_aresta);
				}

				return grafo;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void salvarDimensoes(string nome, int width, int height)
		{
			GrafoLinqDataContext dt = new GrafoLinqDataContext();
			try
			{
				tb_Grafo novoGrafo = dt.tb_Grafos.First(g => g.nome == nome);
				novoGrafo.width = width;
				novoGrafo.height = height;
				dt.SubmitChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
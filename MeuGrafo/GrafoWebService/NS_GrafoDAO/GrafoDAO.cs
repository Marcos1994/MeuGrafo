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

		public GrafoPlus abrirGrafoPlus(string nome)
		{
			GrafoLinqDataContext dt = new GrafoLinqDataContext();
			try
			{
				tb_Grafo grafoAberto = dt.tb_Grafos.First(g => g.nome == nome);
				GrafoPlus grafo = new GrafoPlus();
				grafo.width = grafoAberto.width;
				grafo.height = grafoAberto.height;
				grafo.idGrafo = grafoAberto.id_grafo;
				foreach (tb_Vertice vertice in grafoAberto.tb_Vertices)
					grafo.vertices.Add(new VerticePlus(vertice.nome, vertice.id_vertice, vertice.posX, vertice.posY));
				var arestasDoGrafo = from a in dt.tb_Arestas where a.tb_Vertice.tb_Grafo.nome == nome select a;
				foreach (tb_Aresta aresta in arestasDoGrafo)
					grafo.arestas.Add(new ArestaPlus(aresta.peso, aresta.id_aresta, aresta.id_origem, aresta.id_destino));

				return grafo;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return null;
		}

		public GrafoPlus abrirGrafo(string nome)
		{
			GrafoLinqDataContext dt = new GrafoLinqDataContext();
			try
			{
				tb_Grafo grafoAberto = dt.tb_Grafos.First(g => g.nome == nome);
				GrafoPlus grafo = new GrafoPlus();
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
					grafo.inserirAresta(origem, destino, aresta.peso);
				}

				return grafo;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return null;
		}
	}
}
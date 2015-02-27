using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrafoSimples;
using GrafoWebService.NS_GrafoDAO;

namespace GrafoWebService.NS_GrafoPlus
{
	public class GrafoPlus : Grafo
	{
		public int idGrafo { get; set; }
		public string nome { get; set; }
		public int width { get; set; }
		public int height { get; set; }

		public void inserirVertice(string valor, int posX, int posY, int idVertice)
		{
			vertices.Add(new VerticePlus(valor, idVertice, posX, posY));
		}

		public void inserirAresta(VerticePlus origem, VerticePlus destino, int peso, int idAresta)
		{
			ArestaPlus a = new ArestaPlus(origem, destino, peso, idAresta);
			arestas.Add(a);
			origem.arestas.Add(a);
			destino.arestas.Add(a);
		}

		public void criarVertice(string valor, int posX, int posY)
		{
			VerticeDAO dao = new VerticeDAO();
			dao.criarVertice(this.idGrafo, valor, posX, posY);
		}

		public void criarAresta(int idOrigem, int idDestino, int peso)
		{
			ArestaDAO dao = new ArestaDAO();
			dao.criarAresta(idOrigem, idDestino, peso);
		}

		public GrafoPlus()
		{
		}

		public GrafoPlus(string nome)
		{
			this.nome = nome;
			this.width = 500;
			this.height = 500;
		}

		//Salva o grafo no banco
		public void criarGrafo()
		{
			GrafoDAO dao = new GrafoDAO();
			try
			{
				dao.criarGrafo(this.nome, this.width, this.height);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void abrirGrafoPlus()
		{
			GrafoDAO dao = new GrafoDAO();
			GrafoPlus grafoAux;
			try
			{
				grafoAux = dao.abrirGrafoPlus(this.nome);
				this.idGrafo = grafoAux.idGrafo;
				this.width = grafoAux.width;
				this.height = grafoAux.height;
				this.vertices = grafoAux.vertices;
				this.arestas = grafoAux.arestas;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void abrirGrafo()
		{
			GrafoDAO dao = new GrafoDAO();
			GrafoPlus grafoAux;
			try
			{
				grafoAux = dao.abrirGrafo(this.nome);
				this.idGrafo = grafoAux.idGrafo;
				this.width = grafoAux.width;
				this.height = grafoAux.height;
				this.vertices = grafoAux.vertices;
				this.arestas = grafoAux.arestas;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
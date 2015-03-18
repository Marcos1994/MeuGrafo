using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrafoSimples;
using GrafoWebService.NS_GrafoDAO;
using GrafoWebService.NS_GrafoDTO;

namespace GrafoWebService.NS_GrafoPlus
{
	public class GrafoPlus : Grafo
	{
		public int idGrafo { get; set; }
		public string nome { get; set; }
		public int width { get; set; }
		public int height { get; set; }

		public GrafoPlus(string nome)
		{
			this.nome = nome;
			this.width = 600;
			this.height = 300;
		}

		//Abrir o grafo do banco a partir do nome
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

		//Salva o grafo no banco
		public void criarGrafo()
		{
			GrafoDAO dao = new GrafoDAO();
			try
			{
				dao.criarGrafo(this.nome, this.width, this.height);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		//Adiciona um vertice ja existente ao grafo
		public void inserirVertice(string valor, int posX, int posY, int idVertice)
		{
			VerticePlus v = new VerticePlus(valor, idVertice, posX, posY);
			vertices.Add(v);
		}

		//Adiciona uma aresta ja existente ao grafo
		public void inserirAresta(VerticePlus origem, VerticePlus destino, int peso, int idAresta)
		{
			ArestaPlus a = new ArestaPlus(origem, destino, peso, idAresta);
			arestas.Add(a);
			origem.arestas.Add(a);
			destino.arestas.Add(a);
		}

		//Cria e salva o vertice no banco
		public void criarVertice(string valor, int posX, int posY)
		{
			VerticeDAO dao = new VerticeDAO();
			dao.criarVertice(this.idGrafo, valor, posX, posY);
		}

		//Cria e salva a aresta no banco
		public void criarAresta(int idOrigem, int idDestino, int peso)
		{
			ArestaDAO dao = new ArestaDAO();
			dao.criarAresta(idOrigem, idDestino, peso);
		}

		public GrafoDTO gerarDTO()
		{
			GrafoDTO grafo = new GrafoDTO();
			grafo.idGrafo = this.idGrafo;
			grafo.nome = this.nome;
			grafo.width = this.width;
			grafo.height = this.height;
			foreach (Vertice vertice in this.vertices)
				grafo.vertices.Add(((VerticePlus)vertice).gerarDTO());
			foreach (Aresta aresta in this.arestas)
				grafo.arestas.Add(((ArestaPlus)aresta).gerarDTO());
			return grafo;
		}

		public void salvarDimensoes()
		{
			GrafoDAO dao = new GrafoDAO();
			try
			{
				dao.salvarDimensoes(this.nome, this.width, this.height);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
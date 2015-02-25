using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	public class Grafo
	{
		public List<Vertice> vertices { get; set; }
		public List<Aresta> arestas { get; set; }
		private int visitado;
		
		public Grafo()
		{
			vertices = new List<Vertice>();
			arestas = new List<Aresta>();
			visitado = int.MinValue + 1;
		}

		//Substitui o elemento armazenado no vértice "vertice" por "novoElemento"
		public void substituir(Vertice vertice, Object novoElemento)
		{
			vertice.valor = novoElemento;
		}

		//Substitui o elemento armazenado no vértice "vertice" por "novoElemento"
		public void substituir(Aresta aresta, int novoPeso)
		{
			aresta.peso = novoPeso;
		}

		//Retorna o novo vertice
		public Vertice inserirVertice(Object elemento)
		{
			Vertice v = new Vertice(elemento);
			vertices.Add(v);
			return v;
		}

		//Retorna a nova aresta; O elemento é da aresta
		public Aresta inserirAresta(Vertice origem, Vertice destino, int peso = 0)
		{
			if (peso < 0) peso = 0;
			Aresta a = new Aresta(origem, destino, peso);
			arestas.Add(a);
			origem.arestas.Add(a);
			destino.arestas.Add(a);
			return a;
		}

		//Retorna o valor vertice
		public Object removerVertice(Vertice vertice)
		{
			foreach (var aresta in vertice.arestas)
			{//remover todas as arestas do vertice de seus adjacentes e do grafo
				arestas.Remove(aresta);
				aresta.verticeOposto(vertice).arestas.Remove(aresta);
			}
			vertices.Remove(vertice);
			return vertice.valor;
		}

		//Retorna o elemento da aresta
		public int removerAresta(Aresta aresta)
		{
			aresta.origem.arestas.Remove(aresta);
			aresta.destino.arestas.Remove(aresta);
			arestas.Remove(aresta);
			return aresta.peso;
		}

		//Retorna todas as arestas incidentes ao Vertice "vertice"
		public List<Aresta> arestasIncidentes(Vertice vertice)
		{
			return vertice.arestas;
		}

		//Retorna todos os vertices adjacentes ao Vertice "vertice"
		public List<Vertice> verticesAdjacentes(Vertice vertice)
		{
			List<Vertice> adjacentes = new List<Vertice>();
			foreach (var aresta in vertice.arestas)
				adjacentes.Add(aresta.verticeOposto(vertice));
			return adjacentes;
		}

		//Retorna uma lista de arestas contendo o menor caminho entre dois vertices
		public List<Aresta> menorCaminho(Vertice origem, Vertice destino)
		{
			iterarVisita();
			origem.visitado = visitado;

			int verticesAVisitar = vertices.Count() - 2; //remove a origem e o destino
			ArestaComposta arestaDeMenorPeso;
			Vertice verticeEmVisita;
			Vertice verticeOposto;
			bool caminhoNovo;

			List<ArestaComposta> caminhosPossiveis = new List<ArestaComposta>();
			ArestaComposta caminhoEncontrado = new ArestaComposta(origem, destino);
			foreach (var aresta in origem.arestas)
			{
				verticeOposto = aresta.verticeOposto(origem);
				arestaDeMenorPeso = checarCaminho(caminhosPossiveis, verticeOposto);
				if (arestaDeMenorPeso == null )
					caminhosPossiveis.Add(new ArestaComposta(origem, verticeOposto, aresta));
				else if (aresta.peso < arestaDeMenorPeso.peso)
				{//substituo a aresta pela menor
					arestaDeMenorPeso.peso = aresta.peso;
					arestaDeMenorPeso.caminho.Clear();
					arestaDeMenorPeso.caminho.Add(aresta);
				}
			}

			//enquanto ainda tiver vertices a serem visitados...
			while(verticesAVisitar-- > 0)
			{
				arestaDeMenorPeso = new ArestaComposta();
				foreach (ArestaComposta aresta in caminhosPossiveis)
					if (aresta.verticeOposto(origem).visitado != visitado && aresta.peso < arestaDeMenorPeso.peso)
						arestaDeMenorPeso = aresta;
				if (arestaDeMenorPeso.peso == int.MaxValue) break;
				caminhosPossiveis.Remove(arestaDeMenorPeso);
				verticeOposto = arestaDeMenorPeso.verticeOposto(origem);

				//Ja tenho a aresta de menor peso e o vertice a que ela leva

				//...\\
			}

			return null;
		}

		private void iterarVisita()
		{
			if (visitado == int.MaxValue)
			{
				visitado = int.MinValue;
				foreach (var item in arestas)
					item.visitado = visitado;
				foreach (var item in vertices)
					item.visitado = visitado;
			}
			visitado++;
		}

		private ArestaComposta checarCaminho(List<ArestaComposta> arestasPossiveis, Vertice destino)
		{
			foreach (ArestaComposta aresta in arestasPossiveis)
				if(aresta.destino.Equals(destino))
					return aresta;
			return null;
		}
	}
}

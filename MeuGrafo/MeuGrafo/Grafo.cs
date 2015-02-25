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

		//Retorna o vertice oposto ao vertice passado com base na aresta
		public Vertice verticeOposto(Vertice verticeInicial, Aresta aresta)
		{
			if (aresta.destino.Equals(verticeInicial)) return aresta.origem;
			if (aresta.origem.Equals(verticeInicial)) return aresta.destino;
			throw new GrafoException();
		}

		//Retorna true se vertice1 e vertice2 forem adjacentes
		public bool adjacente(Vertice vertice1, Vertice vertice2)
		{
			foreach (var aresta in vertice1.arestas)
				if (aresta.destino.Equals(vertice2) || aresta.origem.Equals(vertice2))
					return true;
			return false;
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
				verticeOposto(vertice, aresta).arestas.Remove(aresta);
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
				adjacentes.Add(verticeOposto(vertice, aresta));
			return adjacentes;
		}

		//Retorna uma lista de arestas contendo o menor caminho entre dois vertices
		public List<Aresta> menorCaminho(Vertice origem, Vertice destino)
		{



int verticesAVisitar = vertices.Count() - 2; //remo
ArestaComposta arestaDeMenorPeso;
Vertice verticeAuxiliar;
Vertice vOposto;
bool caminhoNovo;

List<ArestaComposta> caminhosPossiveis = new List<ArestaComposta>();
List<Vertice> verticesVisitados = new List<Vertice>(); verticesVisitados.Add(origem);
ArestaComposta caminhoEncontrado = new ArestaComposta(origem, destino);
foreach (var aresta in origem.arestas)
{

	caminhosPossiveis.Add(new ArestaComposta(origem, verticeOposto(origem, aresta), aresta));
}

while (verticesAVisitar-- > 0)
{
	arestaDeMenorPeso = new ArestaComposta();

	//pegue a aresta de menor peso
	foreach (var aresta in caminhosPossiveis)
	{
		//Se o destino ainda não foi visitado (Origem ou Destino ja foram visitados - nem os dois e nem só um)
		if (verticesVisitados.Contains(aresta.destino) != verticesVisitados.Contains(aresta.origem))
			if (aresta.peso < arestaDeMenorPeso.peso)
				arestaDeMenorPeso = aresta;
	}
	//Se não tiver mais nenhum caminho possível ou todos os destinos dos caminhos ja foram visitados
	if (caminhosPossiveis.Count < 1 || arestaDeMenorPeso.peso == int.MaxValue)
		break; //saia do laço e retorne o caminho encontrado

	//Hora de criar arestas compostas para todas as arestas do vertice

	//Adiciono o vertice a ser visitado no array de visitados
	if (verticesVisitados.Contains(arestaDeMenorPeso.destino))
		verticeAuxiliar = arestaDeMenorPeso.origem;
	else
		verticeAuxiliar = arestaDeMenorPeso.destino;
	verticesVisitados.Add(verticeAuxiliar);

	foreach (var aresta in verticeAuxiliar.arestas)
	{
		if (arestaDeMenorPeso.peso + aresta.peso < caminhoEncontrado.peso)
		{//se esse novo caminho for menor do que o já encontrado...
			vOposto = verticeOposto(verticeAuxiliar, aresta);
			//Se o vertice oposto ja foi visitado, é porque tem um caminho menor do que esse para ele
			if (!verticesVisitados.Contains(vOposto))
			{//Verifico se ja existe um caminho pra esse destino
				caminhoNovo = true;
				foreach (var arestaPossivel in caminhosPossiveis)
					if (vOposto == arestaPossivel.destino || vOposto == arestaPossivel.origem)
					{//ja existe caminho
						if (arestaDeMenorPeso.peso + aresta.peso < arestaPossivel.peso)
						{//o novo caminho é menor
							//altero o peso
							arestaPossivel.peso = arestaDeMenorPeso.peso + aresta.peso;
							//passo o novo caminho para o vertice (caminho até o verticeAuxiliar e dele para o vertice) à aresta
							arestaPossivel.caminho = arestaDeMenorPeso.caminho;
							arestaPossivel.caminho.Add(aresta);
							caminhoNovo = false;
						}
						break;
					}
				if (caminhoNovo)
				{//primeiro caminho encontrado para esse vertice
					ArestaComposta nac = new ArestaComposta(origem, vOposto, arestaDeMenorPeso.peso + aresta.peso, arestaDeMenorPeso);
					nac.caminho.Add(aresta);
					caminhosPossiveis.Add(nac);
				}
			}
		}
	}
}

//se nenhum caminho for encontrado...
if (caminhoEncontrado.peso < 0)
	throw new GrafoException();

return caminhoEncontrado.caminho;



		}

		private void menorCaminhoEncontrado()
		{

		}
	}
}

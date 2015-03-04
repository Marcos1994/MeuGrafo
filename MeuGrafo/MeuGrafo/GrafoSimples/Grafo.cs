using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoSimples
{
	public class Grafo
	{
		public List<Vertice> vertices;
		public List<Aresta> arestas;
		private int visitado;

		/*/
		 *v = vertices
		 *a = arestas
		/*/

		/*O(v + a)*/
		private void iterarVisita()
		{
			if (visitado == int.MaxValue)
			{
				visitado = int.MinValue;
				//todos os vertices e arestas receberão o valor de visitado=min, para que não ocorra de um vertice não visitado seja dado como visitado
				foreach (var item in arestas)
					item.visitado = visitado;
				foreach (var item in vertices)
					item.visitado = visitado;
			}
			visitado++;
		}

		/*O(?)*/
		private ArestaComposta checarCaminho(List<ArestaComposta> arestasPossiveis, Vertice destino)
		{
			foreach (ArestaComposta aresta in arestasPossiveis)
				if (aresta.destino.Equals(destino))
					return aresta;
			return null;
		}
		
		public Grafo()
		{
			vertices = new List<Vertice>();
			arestas = new List<Aresta>();
			visitado = int.MinValue + 1;
		}

		/*O(v)*/
		public Vertice vertice(Object valor)
		{
			foreach (Vertice v in vertices)
				if (v.valor.Equals(valor))
					return v;
			throw new GrafoException("Nenhum vertice encontrado!");
		}

		/*O(1)*/
		public void editarVertice(Vertice vertice, Object novoElemento)
		{
			vertice.valor = novoElemento;
		}

		/*O(1)*/
		public void editarAresta(Aresta aresta, int novoPeso)
		{
			aresta.peso = novoPeso;
		}

		/*O(v)*/
		public Vertice inserirVertice(Object elemento)
		{
			Vertice vertice = new Vertice(elemento);
			bool jaExiste = false;
			foreach (Vertice v in vertices)
				if (v.valor.Equals(elemento))
				{
					jaExiste = true;
					break;
				}
			if (jaExiste)
				throw new GrafoException("Ja existe um vertice com esse valor");
			vertices.Add(vertice);
			return vertice;
		}

		/*O(log(a))*/
		public Aresta inserirAresta(Vertice origem, Vertice destino, int peso = 0)
		{
			Aresta a = new Aresta(origem, destino, peso);
			arestas.Add(a);
			origem.arestas.Add(a);
			destino.arestas.Add(a);
			return a;
		}

		/*O(v * a)*/
		public Object removerVertice(Vertice vertice)
		{
			Aresta[] arestasAdjacentes = vertice.arestas.ToArray();
			foreach (var aresta in arestasAdjacentes)
			{//remover todas as arestas do vertice de seus adjacentes e do grafo
				arestas.Remove(aresta);
				aresta.verticeOposto(vertice).arestas.Remove(aresta);
			}
			vertices.Remove(vertice);
			return vertice.valor;
		}

		/*O(n)*/
		public int removerAresta(Aresta aresta)
		{
			aresta.origem.arestas.Remove(aresta);
			aresta.destino.arestas.Remove(aresta);
			arestas.Remove(aresta);
			return aresta.peso;
		}

		/*O(n)*/
		public Aresta[] arestasIncidentes(Vertice vertice)
		{
			return vertice.arestas.ToArray();
		}

		/*------------------ Menor Caminho ------------------*/
		//Retorna uma lista de arestas contendo o menor caminho entre dois vertices
		public List<Aresta> menorCaminho(Vertice origem, Vertice destino)
		{
			iterarVisita();
			origem.visitado = visitado;
			
			ArestaComposta arestaDeMenorPeso;
			ArestaComposta arestaNova;
			Vertice verticeEmVisita;

			Heap caminhosPossiveis = new Heap();
			Heap caminhosAuxiliares = origem.arestas.Clone();
			ArestaComposta caminhoEncontrado = new ArestaComposta(origem, destino);

			while (caminhosAuxiliares.Count() > 0)
			{
				if (caminhosAuxiliares.Top().peso < caminhoEncontrado.peso)
				{
					arestaDeMenorPeso = ((ArestaComposta)caminhosAuxiliares.Top());
					if (arestaDeMenorPeso.verticeOposto(origem).Equals(destino))
					{
						caminhoEncontrado.peso = arestaDeMenorPeso.peso;
						caminhoEncontrado.caminho.Clear();
						caminhoEncontrado.caminho.Add(caminhosAuxiliares.Remove());
						//caminhosPossiveis.removerMaioresQue(caminhoEncontrado.peso);
						//Não precisa remover os caminhos maiores que ele pelo fato de que os caminhos são retirados em ordem crescente
						break; //Ja achei o menor caminho direto para o destino
					}
					else
						caminhosPossiveis.Add(new ArestaComposta(origem, arestaDeMenorPeso.verticeOposto(origem), arestaDeMenorPeso.peso, caminhosAuxiliares.Remove()));
				}
			}

			//enquanto ainda existirem caminhos possíveis menores que o caminho já encontrado...
			while (caminhosPossiveis.Count() > 0 && caminhosPossiveis.Top().peso < caminhoEncontrado.peso)
			{
				arestaDeMenorPeso = (ArestaComposta)(caminhosPossiveis.Remove());
				verticeEmVisita = arestaDeMenorPeso.verticeOposto(origem);
				//se o destino desse caminho ainda não foi visitado
				if (verticeEmVisita.visitado != visitado)
				{
					verticeEmVisita.visitado = visitado;
					caminhosAuxiliares = verticeEmVisita.arestas.Clone();
					//enquanto ainda existirem caminhos relativos menores que o caminho já encontrado...
					while (arestaDeMenorPeso.peso + caminhosAuxiliares.Top().peso < caminhoEncontrado.peso)
					{
						if (caminhosAuxiliares.Top().destino.Equals(destino))
						{
							caminhoEncontrado.peso = arestaDeMenorPeso.peso + caminhosAuxiliares.Top().peso;
							caminhoEncontrado.caminho.Clear();
							foreach (Aresta a in arestaDeMenorPeso.caminho)
								caminhoEncontrado.caminho.Add(a);
							caminhoEncontrado.caminho.Add(caminhosAuxiliares.Remove());
							caminhosPossiveis.removerMaioresQue(caminhoEncontrado.peso);
							break; //Ja achei o menor caminho para o destino a partir desse vertice
						}
						else
						{
							arestaNova = new ArestaComposta(origem, arestaDeMenorPeso.verticeOposto(origem));
							arestaNova.peso = arestaDeMenorPeso.peso + caminhosAuxiliares.Top().peso;
							foreach (Aresta a in arestaDeMenorPeso.caminho)
								caminhoEncontrado.caminho.Add(a);
							arestaNova.caminho.Add(caminhosAuxiliares.Remove());
							caminhosPossiveis.Add(arestaNova);
						}
					}
				}
			}

			if (caminhoEncontrado.caminho.Count > 0)
				return caminhoEncontrado.caminho;

			return null;
		}

		/*------------------ A*++ ------------------*/
		//Retorna uma lista de arestas contendo o menor caminho entre dois vertices
		public List<Aresta> menorCaminho(Vertice origem, Object chaveDestino)
		{
			iterarVisita();
			origem.visitado = visitado;

			ArestaComposta arestaDeMenorPeso;
			ArestaComposta arestaNova;
			Vertice verticeEmVisita;

			Heap caminhosPossiveis = new Heap();
			Heap caminhosAuxiliares = origem.arestas.Clone();
			Vertice destino = new Vertice(chaveDestino);
			ArestaComposta caminhoEncontrado = new ArestaComposta(origem, destino);

			while (caminhosAuxiliares.Count() > 0)
			{
				if (caminhosAuxiliares.Top().peso < caminhoEncontrado.peso)
				{
                    Aresta arestaAux = caminhosAuxiliares.Top();
                    if (arestaAux.verticeOposto(origem).valor.Equals(chaveDestino))
					{
                        caminhoEncontrado.peso = arestaAux.peso;
						caminhoEncontrado.caminho.Clear();
						caminhoEncontrado.caminho.Add(caminhosAuxiliares.Remove());
						//caminhosPossiveis.removerMaioresQue(caminhoEncontrado.peso);
						//Não precisa remover os caminhos maiores que ele pelo fato de que os caminhos são retirados em ordem crescente
						break; //Ja achei o menor caminho direto para o destino
					}
					else
                        caminhosPossiveis.Add(new ArestaComposta(origem, arestaAux.verticeOposto(origem), arestaAux.peso, caminhosAuxiliares.Remove()));
				}
			}

			//enquanto ainda existirem caminhos possíveis menores que o caminho já encontrado...
			while (caminhosPossiveis.Count() > 0 && caminhosPossiveis.Top().peso < caminhoEncontrado.peso)
			{
				arestaDeMenorPeso = (ArestaComposta)(caminhosPossiveis.Remove());
				verticeEmVisita = arestaDeMenorPeso.verticeOposto(origem);
				//se o destino desse caminho ainda não foi visitado
				if (verticeEmVisita.visitado != visitado)
				{
					verticeEmVisita.visitado = visitado;
					caminhosAuxiliares = verticeEmVisita.arestas.Clone();
					//enquanto ainda existirem caminhos relativos menores que o caminho já encontrado...
					while (caminhosAuxiliares.Count() > 0 && arestaDeMenorPeso.peso + caminhosAuxiliares.Top().peso < caminhoEncontrado.peso)
					{
						Aresta arestaEmVisita = caminhosAuxiliares.Remove();
						if (arestaEmVisita.verticeOposto(verticeEmVisita).visitado != visitado)
						{
							if (arestaEmVisita.verticeOposto(verticeEmVisita).valor.Equals(chaveDestino))
							{
								caminhoEncontrado.peso = arestaDeMenorPeso.peso + arestaEmVisita.peso;
								caminhoEncontrado.caminho.Clear();
								foreach (Aresta a in arestaDeMenorPeso.caminho)
									caminhoEncontrado.caminho.Add(a);
								caminhoEncontrado.caminho.Add(arestaEmVisita);
								caminhosPossiveis.removerMaioresQue(caminhoEncontrado.peso);
								break; //Ja achei o menor caminho para o destino a partir desse vertice
							}
							else
							{
								arestaNova = new ArestaComposta(origem, arestaEmVisita.verticeOposto(verticeEmVisita));
								arestaNova.peso = arestaDeMenorPeso.peso + arestaEmVisita.peso;
								foreach (Aresta a in arestaDeMenorPeso.caminho)
									arestaNova.caminho.Add(a);
								arestaNova.caminho.Add(arestaEmVisita);
								caminhosPossiveis.Add(arestaNova);
							}
						}
					}
				}
			}

			if (caminhoEncontrado.caminho.Count > 0)
				return caminhoEncontrado.caminho;

			return null;
		}
	}
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoSimples
{
	public class Grafo
	{
		public List<Vertice> vertices { get; set; }
		public List<Aresta> arestas { get; set; }
		private int visitado;

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
			return vertice.verticesAdjacentes();
		}

		/*------------------ Menor Caminho ------------------*/
		//Retorna uma lista de arestas contendo o menor caminho entre dois vertices
		public List<Aresta> menorCaminho(Vertice origem, Vertice destino)
		{
			iterarVisita();
			origem.visitado = visitado;

			ArestaComposta arestaDeMenorPeso;
			Vertice verticeEmVisita;
			Vertice verticeOposto;

			List<ArestaComposta> caminhosPossiveis = new List<ArestaComposta>(); //Poderia ser uma heap com chave = aresta.peso
			ArestaComposta caminhoEncontrado = new ArestaComposta(origem, destino);
			foreach (var aresta in origem.arestas)
			{
				if (aresta.peso < caminhoEncontrado.peso)
				{//ignora qualquer caminho que seja maior do que o encontrado para o destino
					verticeOposto = aresta.verticeOposto(origem);
					if (verticeOposto.Equals(destino))
					{//É um caminho pro vertice de destino
						caminhoEncontrado.destino = verticeOposto;
						caminhoEncontrado.peso = aresta.peso;
						caminhoEncontrado.caminho.Clear();
						caminhoEncontrado.caminho.Add(aresta);
						//Removo todos os caminhos que sejam maiores ou iguais ao caminho encontrado
						caminhosPossiveis.RemoveAll(a => a.peso >= caminhoEncontrado.peso);
					}
					else
					{//É um caminho para um vertice qualquer
						//Verifico se ja tem um caminho para esse vertice
						arestaDeMenorPeso = checarCaminho(caminhosPossiveis, verticeOposto);
						if (arestaDeMenorPeso == null) //Não tem nenhum caminho pra esse vertice
							caminhosPossiveis.Add(new ArestaComposta(origem, verticeOposto, aresta));
						else if (aresta.peso < arestaDeMenorPeso.peso)
						{//substituo o caminho para o vertice pelo caminho menor
							arestaDeMenorPeso.peso = aresta.peso;
							arestaDeMenorPeso.caminho.Clear();
							arestaDeMenorPeso.caminho.Add(aresta);
						}
					}
				}
			}

			//enquanto ainda tiver vertices a serem visitados...
			while (caminhosPossiveis.Count() > 0)
			{
				arestaDeMenorPeso = new ArestaComposta();
				//verifico qual dos caminhos cujo destino ainda não foi visitado tem menor peso
				foreach (ArestaComposta aresta in caminhosPossiveis)
					if (aresta.verticeOposto(origem).visitado != visitado && aresta.peso < arestaDeMenorPeso.peso)
						arestaDeMenorPeso = aresta;
				if (arestaDeMenorPeso.peso == int.MaxValue) break; //Se não foi encontrado nenhum caminho possível
				caminhosPossiveis.Remove(arestaDeMenorPeso);//Removo o caminho que estou visitando dos caminhos possíveis
				verticeEmVisita = arestaDeMenorPeso.verticeOposto(origem); //Pego o vertice que irei visitar
				verticeEmVisita.visitado = visitado; //Informo que o vertice foi(será)visitado

				//Ja tenho a aresta de menor peso e o vertice a que ela leva

				foreach (var aresta in verticeEmVisita.arestas)
				{//vou ver pra onde esse vertice pode ir e criar os caminhos
					verticeOposto = aresta.verticeOposto(verticeEmVisita);
					if ((verticeOposto.visitado != visitado) && (aresta.peso < caminhoEncontrado.peso))
					{//ignora qualquer caminho cujo destino ja tenha sido visitado e que seja maior ou igual do que o encontrado para o destino
						if (verticeOposto.Equals(destino))
						{//É um caminho pro vertice de destino
							if (arestaDeMenorPeso.peso + aresta.peso < caminhoEncontrado.peso)
							{
								caminhoEncontrado.destino = verticeOposto;
								caminhoEncontrado.peso = arestaDeMenorPeso.peso + aresta.peso;
								caminhoEncontrado.caminho.Clear();
								foreach (Aresta are in ((ArestaComposta)arestaDeMenorPeso).caminho)
									caminhoEncontrado.caminho.Add(are);
								caminhoEncontrado.caminho.Add(aresta);
								//Removo todos os caminhos que sejam maiores ou iguais ao caminho encontrado
								caminhosPossiveis.RemoveAll(a => a.peso >= caminhoEncontrado.peso);
							}
						}
						else
						{//É um caminho para um vertice qualquer
							//Verifico se ja tem um caminho para esse vertice
							ArestaComposta arestaExistente = checarCaminho(caminhosPossiveis, verticeOposto);
							if (arestaExistente == null) //Não tem nenhum caminho pra esse vertice
							{
								arestaExistente = new ArestaComposta(origem, verticeOposto);
								arestaExistente.peso = arestaDeMenorPeso.peso + aresta.peso;
								arestaExistente.caminho.Clear();
								foreach (Aresta are in ((ArestaComposta)arestaDeMenorPeso).caminho)
									arestaExistente.caminho.Add(are);
								arestaExistente.caminho.Add(aresta);
								caminhosPossiveis.Add(arestaExistente);
							}
							else if (aresta.peso + arestaDeMenorPeso.peso < arestaExistente.peso)
							{//substituo o caminho para o vertice pelo caminho menor
								arestaExistente.peso = aresta.peso + arestaDeMenorPeso.peso;
								arestaExistente.caminho.Clear();
								foreach (Aresta are in ((ArestaComposta)arestaDeMenorPeso).caminho)
									arestaExistente.caminho.Add(are);
								arestaExistente.caminho.Add(aresta);
							}
						}
					}
				}
			}

			if (caminhoEncontrado.peso != int.MaxValue)
				return caminhoEncontrado.caminho;

			return null;
		}

		//Retorna uma lista de arestas contendo o menor caminho entre um vertice de origem e um valor de destino
		public List<Aresta> menorCaminho(Vertice origem, Object chaveDestino)
		{
			iterarVisita();
			origem.visitado = visitado;

			ArestaComposta arestaDeMenorPeso;
			Vertice verticeEmVisita;
			Vertice verticeOposto;

			List<ArestaComposta> caminhosPossiveis = new List<ArestaComposta>(); //Poderia ser uma heap com chave = aresta.peso
			Vertice destino = new Vertice(chaveDestino);
			ArestaComposta caminhoEncontrado = new ArestaComposta(origem, destino);
			foreach (var aresta in origem.arestas)
			{
				if (aresta.peso < caminhoEncontrado.peso)
				{//ignora qualquer caminho que seja maior do que o encontrado para o destino
					verticeOposto = aresta.verticeOposto(origem);
					if (verticeOposto.valor.Equals(chaveDestino))
					{//É um caminho pro vertice de destino
						caminhoEncontrado.destino = verticeOposto;
						caminhoEncontrado.peso = aresta.peso;
						caminhoEncontrado.caminho.Clear();
						caminhoEncontrado.caminho.Add(aresta);
						//Removo todos os caminhos que sejam maiores ou iguais ao caminho encontrado
						caminhosPossiveis.RemoveAll(a => a.peso >= caminhoEncontrado.peso);
					}
					else
					{//É um caminho para um vertice qualquer
						//Verifico se ja tem um caminho para esse vertice
						arestaDeMenorPeso = checarCaminho(caminhosPossiveis, verticeOposto);
						if (arestaDeMenorPeso == null) //Não tem nenhum caminho pra esse vertice
							caminhosPossiveis.Add(new ArestaComposta(origem, verticeOposto, aresta));
						else if (aresta.peso < arestaDeMenorPeso.peso)
						{//substituo o caminho para o vertice pelo caminho menor
							arestaDeMenorPeso.peso = aresta.peso;
							arestaDeMenorPeso.caminho.Clear();
							arestaDeMenorPeso.caminho.Add(aresta);
						}
					}
				}
			}

			//enquanto ainda tiver vertices a serem visitados...
			while (caminhosPossiveis.Count() > 0)
			{
				arestaDeMenorPeso = new ArestaComposta();
				//verifico qual dos caminhos cujo destino ainda não foi visitado tem menor peso
				foreach (ArestaComposta aresta in caminhosPossiveis)
					if (aresta.verticeOposto(origem).visitado != visitado && aresta.peso < arestaDeMenorPeso.peso)
						arestaDeMenorPeso = aresta;
				if (arestaDeMenorPeso.peso == int.MaxValue) break; //Se não foi encontrado nenhum caminho possível
				caminhosPossiveis.Remove(arestaDeMenorPeso);//Removo o caminho que estou visitando dos caminhos possíveis
				verticeEmVisita = arestaDeMenorPeso.verticeOposto(origem); //Pego o vertice que irei visitar
				verticeEmVisita.visitado = visitado; //Informo que o vertice foi(será)visitado

				//Ja tenho a aresta de menor peso e o vertice a que ela leva

				foreach (var aresta in verticeEmVisita.arestas)
				{//vou ver pra onde esse vertice pode ir e criar os caminhos
					verticeOposto = aresta.verticeOposto(verticeEmVisita);
					if ((verticeOposto.visitado != visitado) && (aresta.peso < caminhoEncontrado.peso))
					{//ignora qualquer caminho cujo destino ja tenha sido visitado e que seja maior ou igual do que o encontrado para o destino
						if (verticeOposto.valor.Equals(chaveDestino))
						{//É um caminho pro vertice de destino
							if (arestaDeMenorPeso.peso + aresta.peso < caminhoEncontrado.peso)
							{
								caminhoEncontrado.destino = verticeOposto;
								caminhoEncontrado.peso = arestaDeMenorPeso.peso + aresta.peso;
								caminhoEncontrado.caminho.Clear();
								foreach (Aresta are in ((ArestaComposta)arestaDeMenorPeso).caminho)
									caminhoEncontrado.caminho.Add(are);
								caminhoEncontrado.caminho.Add(aresta);
								//Removo todos os caminhos que sejam maiores ou iguais ao caminho encontrado
								caminhosPossiveis.RemoveAll(a => a.peso >= caminhoEncontrado.peso);
							}
						}
						else
						{//É um caminho para um vertice qualquer
							//Verifico se ja tem um caminho para esse vertice
							ArestaComposta arestaExistente = checarCaminho(caminhosPossiveis, verticeOposto);
							if (arestaExistente == null) //Não tem nenhum caminho pra esse vertice
							{
								arestaExistente = new ArestaComposta(origem, verticeOposto);
								arestaExistente.peso = arestaDeMenorPeso.peso + aresta.peso;
								arestaExistente.caminho.Clear();
								foreach (Aresta are in ((ArestaComposta)arestaDeMenorPeso).caminho)
									arestaExistente.caminho.Add(are);
								arestaExistente.caminho.Add(aresta);
								caminhosPossiveis.Add(arestaExistente);
							}
							else if (aresta.peso + arestaDeMenorPeso.peso < arestaExistente.peso)
							{//substituo o caminho para o vertice pelo caminho menor
								arestaExistente.peso = aresta.peso + arestaDeMenorPeso.peso;
								arestaExistente.caminho.Clear();
								foreach (Aresta are in ((ArestaComposta)arestaDeMenorPeso).caminho)
									arestaExistente.caminho.Add(are);
								arestaExistente.caminho.Add(aresta);
							}
						}
					}
				}
			}

			if (caminhoEncontrado.peso != int.MaxValue)
				return caminhoEncontrado.caminho;

			return null;
		}

		public ArrayList colorirGrafo()
		{
			if (vertices.Count > 0)
			{
				iterarVisita();								//Itero a visita
				int verticesRestantes = vertices.Count;		//Defino um contador
				Queue<Vertice> fila = new Queue<Vertice>();	//Crio a fila para busca em largura
				ArrayList cores = new ArrayList();			//Crio o array de cores
				fila.Enqueue(vertices.First());				//Pego um vertice qualquer e coloco na fila
				Vertice verticeEmVisita;
				List<Vertice> adjacentes;
				int indiceCor;
				bool temAdjacente;
				while (verticesRestantes-- > 0)
				{
					if (fila.Count < 1)					//Se a fila estiver vazia
						foreach (Vertice v in vertices)	//Vou procurar nos vertices
							if (v.visitado != visitado)	//Algum que não tenha sido visitado
							{							//Então
								fila.Enqueue(v);		//Enfileiro
								break;					//E continuo
							}

					verticeEmVisita = fila.Dequeue();					//Pego o primeiro vertice da fila
					verticeEmVisita.visitado = visitado;				//Digo que ele está sendo visitado
					adjacentes = verticeEmVisita.verticesAdjacentes();	//Pego seus adjacentes
					foreach (Vertice v in adjacentes)					//E dos adjacentes...
						if (v.visitado != visitado)						//Aquele que não foi visitado...
							fila.Enqueue(v);							//Eu enfileiro

					//Vou percorrer todas as cores procurando aquela que não contenha nenhum dos adjacentes do VerticeEmVisita
					for (indiceCor = 0; indiceCor < cores.Count; indiceCor++)
					{
						temAdjacente = false;
						foreach(Vertice adj in adjacentes)
							if (((List<Vertice>)cores[indiceCor]).Contains(adj))
							{
								temAdjacente = true;
								break;
							}

						if (!temAdjacente)	//Quando achar alguma cor que não tenha nenhum dos adjacentes
							break;			//Break! e adiciono-o à cor
					}

					if (indiceCor == cores.Count)		//Se ele saiu do laço por falta de cores
						cores.Add(new List<Vertice>());	//Crio uma nova cor

					//Se saiu por falta de cores ou por que achou uma cor que não tem adjacentes à ele
					//Adiciono o vertice ao indice da cor
					((List<Vertice>)cores[indiceCor]).Add(verticeEmVisita);
				}

				return cores;
			}
			return null;
		}
	}
}

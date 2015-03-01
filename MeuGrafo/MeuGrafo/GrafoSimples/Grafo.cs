﻿using System;
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
			Vertice verticeOposto;
			bool caminhoNovo;

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

			//enquanto ainda tiver vertices a serem visitados...
			while (caminhosPossiveis.Count() > 0 && caminhosPossiveis.Top().peso < caminhoEncontrado.peso)
			{

			}

			if (caminhoEncontrado.caminho.Count > 0)
				return caminhoEncontrado.caminho;

			return null;
		}

		///*------------------ A*++ ------------------*/
		////Retorna uma lista de arestas contendo o menor caminho entre dois vertices
		//public List<Aresta> menorCaminho(Vertice origem, Object chaveDestino)
		//{
		//	iterarVisita();
		//	origem.visitado = visitado;

		//	int verticesAVisitar = vertices.Count() - 1; //remove a origem e o destino
		//	ArestaComposta arestaDeMenorPeso;
		//	Vertice verticeEmVisita;
		//	Vertice verticeOposto;
		//	bool caminhoNovo;

		//	List<ArestaComposta> caminhosPossiveis = new List<ArestaComposta>(); //Poderia ser uma heap com chave = aresta.peso
		//	Vertice destino = new Vertice(chaveDestino);
		//	ArestaComposta caminhoEncontrado = new ArestaComposta(origem, destino);
		//	foreach (var aresta in origem.arestas)
		//	{
		//		if (aresta.peso < caminhoEncontrado.peso)
		//		{//ignora qualquer caminho que seja maior do que o encontrado para o destino
		//			verticeOposto = aresta.verticeOposto(origem);
		//			if (verticeOposto.valor.Equals(chaveDestino))
		//			{//É um caminho pro vertice de destino
		//				caminhoEncontrado.destino = verticeOposto;
		//				caminhoEncontrado.peso = aresta.peso;
		//				caminhoEncontrado.caminho.Clear();
		//				caminhoEncontrado.caminho.Add(aresta);
		//				//Removo todos os caminhos que sejam maiores ou iguais ao caminho encontrado
		//				caminhosPossiveis.RemoveAll(a => a.peso >= caminhoEncontrado.peso);
		//			}
		//			else
		//			{//É um caminho para um vertice qualquer
		//				//Verifico se ja tem um caminho para esse vertice
		//				arestaDeMenorPeso = checarCaminho(caminhosPossiveis, verticeOposto);
		//				if (arestaDeMenorPeso == null) //Não tem nenhum caminho pra esse vertice
		//					caminhosPossiveis.Add(new ArestaComposta(origem, verticeOposto, aresta));
		//				else if (aresta.peso < arestaDeMenorPeso.peso)
		//				{//substituo o caminho para o vertice pelo caminho menor
		//					arestaDeMenorPeso.peso = aresta.peso;
		//					arestaDeMenorPeso.caminho.Clear();
		//					arestaDeMenorPeso.caminho.Add(aresta);
		//				}
		//			}
		//		}
		//	}

		//	//enquanto ainda tiver vertices a serem visitados...
		//	while (verticesAVisitar-- > 0)
		//	{
		//		arestaDeMenorPeso = new ArestaComposta();
		//		//verifico qual dos caminhos cujo destino ainda não foi visitado tem menor peso
		//		foreach (ArestaComposta aresta in caminhosPossiveis)
		//			if (aresta.verticeOposto(origem).visitado != visitado && aresta.peso < arestaDeMenorPeso.peso)
		//				arestaDeMenorPeso = aresta;
		//		if (arestaDeMenorPeso.peso == int.MaxValue) break; //Se não foi encontrado nenhum caminho possível
		//		caminhosPossiveis.Remove(arestaDeMenorPeso);//Removo o caminho que estou visitando dos caminhos possíveis
		//		verticeEmVisita = arestaDeMenorPeso.verticeOposto(origem); //Pego o vertice que irei visitar
		//		verticeEmVisita.visitado = visitado; //Informo que o vertice foi(será)visitado

		//		//Ja tenho a aresta de menor peso e o vertice a que ela leva

		//		foreach (var aresta in verticeEmVisita.arestas)
		//		{//vou ver pra onde esse vertice pode ir e criar os caminhos
		//			verticeOposto = aresta.verticeOposto(verticeEmVisita);
		//			if ((verticeOposto.visitado != visitado) && (aresta.peso < caminhoEncontrado.peso))
		//			{//ignora qualquer caminho cujo destino ja tenha sido visitado e que seja maior ou igual do que o encontrado para o destino
		//				if (verticeOposto.valor.Equals(chaveDestino))
		//				{//É um caminho pro vertice de destino
		//					if (arestaDeMenorPeso.peso + aresta.peso < caminhoEncontrado.peso)
		//					{
		//						caminhoEncontrado.destino = verticeOposto;
		//						caminhoEncontrado.peso = arestaDeMenorPeso.peso + aresta.peso;
		//						caminhoEncontrado.caminho.Clear();
		//						foreach (Aresta are in ((ArestaComposta)arestaDeMenorPeso).caminho)
		//							caminhoEncontrado.caminho.Add(are);
		//						caminhoEncontrado.caminho.Add(aresta);
		//						//Removo todos os caminhos que sejam maiores ou iguais ao caminho encontrado
		//						caminhosPossiveis.RemoveAll(a => a.peso >= caminhoEncontrado.peso);
		//					}
		//				}
		//				else
		//				{//É um caminho para um vertice qualquer
		//					//Verifico se ja tem um caminho para esse vertice
		//					ArestaComposta arestaExistente = checarCaminho(caminhosPossiveis, verticeOposto);
		//					if (arestaExistente == null) //Não tem nenhum caminho pra esse vertice
		//					{
		//						arestaExistente = new ArestaComposta(origem, verticeOposto);
		//						arestaExistente.peso = arestaDeMenorPeso.peso + aresta.peso;
		//						arestaExistente.caminho.Clear();
		//						foreach (Aresta are in ((ArestaComposta)arestaDeMenorPeso).caminho)
		//							arestaExistente.caminho.Add(are);
		//						arestaExistente.caminho.Add(aresta);
		//						caminhosPossiveis.Add(arestaExistente);
		//					}
		//					else if (aresta.peso + arestaDeMenorPeso.peso < arestaExistente.peso)
		//					{//substituo o caminho para o vertice pelo caminho menor
		//						arestaExistente.peso = aresta.peso + arestaDeMenorPeso.peso;
		//						arestaExistente.caminho.Clear();
		//						foreach (Aresta are in ((ArestaComposta)arestaDeMenorPeso).caminho)
		//							arestaExistente.caminho.Add(are);
		//						arestaExistente.caminho.Add(aresta);
		//					}
		//				}
		//			}
		//		}
		//	}

		//	if (caminhoEncontrado.peso != int.MaxValue)
		//		return caminhoEncontrado.caminho;

		//	return null;
		//}
	}
}

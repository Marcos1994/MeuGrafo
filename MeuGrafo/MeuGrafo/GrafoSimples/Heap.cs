using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoSimples
{
	class Heap
	{
		private Aresta[] arestas;
		private int tamanho;
		private int proximoElemento;
		private int maiorPeso;

		public Heap()
		{
			proximoElemento = 0;
			tamanho = 16;
			arestas = new Aresta[tamanho];
			maiorPeso = int.MinValue;
		}

		/*O(log(n))*/
		private void upHeap(int posicao)
		{
			int posicaoPai;
			Aresta aux;
			while (posicao > 0)
			{
				posicaoPai = (posicao - 1) / 2;
				if (arestas[posicaoPai].peso <= arestas[posicao].peso)
					break;
				aux = arestas[posicaoPai];
				arestas[posicaoPai] = arestas[posicao];
				arestas[posicao] = aux;
				posicao = posicaoPai;
			}
		}

		/*O(log(n))*/
		private void downHeap()
		{
			int posicao = 0;
			int limite = (proximoElemento-1)/2;
			Aresta aux;
			int filho;
			while(posicao <= limite)
			{/*Enquanto ele estiver dentro do limite, terá pelo menois 1 filho*/
				filho = (posicao * 2 + 1);
				if (filho + 1 <= proximoElemento) /*se tem filho direito, tem filho esquerdo*/
					if (arestas[filho].peso > arestas[filho + 1].peso)//Se o filho direito for menor que o esquerto, escolha-o
						filho++;
				if (arestas[posicao].peso > arestas[filho].peso)
				{
					aux = arestas[(posicao * 2 + 1)];
					arestas[filho] = arestas[posicao];
					arestas[posicao] = aux;
					posicao = filho;
				}
				else
					break;
			}
		}

		/*O(n)*/
		private void expandirArestas()
		{
			if (proximoElemento == tamanho)
			{
				tamanho *= 2;
				Aresta[] aux = arestas;
				arestas = new Aresta[tamanho];
				for (int i = 0; i < proximoElemento; i++)
					arestas[i] = aux[i];
			}
		}

		/*O(1)*/
		private void atualizarMaiorPeso(int peso)
		{
			if (peso > maiorPeso)
				maiorPeso = peso;
		}

		/*O(log(n))*/
		public void inserir(Aresta aresta)
		{
			expandirArestas();
			arestas[proximoElemento] = aresta;
			upHeap(proximoElemento);
			atualizarMaiorPeso(aresta.peso);
			proximoElemento++;
		}

		/*O(1)*/
		public Aresta visualizarTopo()
		{
			if (proximoElemento == 0)
				throw new HeapException("A Heap está vazia");
			return arestas[0];
		}

		/*O(log(n))*/
		public Aresta remover()
		{
			if (proximoElemento == 0)
				throw new HeapException("A Heap está vazia");
			Aresta retorno = arestas[0];
			arestas[0] = arestas[--proximoElemento];
			if (proximoElemento == 0) /*Como eu removo sempre a aresta de menor peso, o maior peso será o ultimo a sair.*/
				maiorPeso = int.MinValue;
			downHeap();
			return retorno;
		}

		/*O(n*log(n))*/
		public void removerMenoresQue(int peso)
		{
			if (proximoElemento != 0)
			{
			}
		}
	}
}

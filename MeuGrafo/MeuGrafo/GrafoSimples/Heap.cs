using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoSimples
{
	public class Heap
	{
		public Aresta[] arestas { get; set; }
		public int tamanho { get; set; }
		public int proximoElemento { get; set; }
		public int maiorPeso { get; set; }

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
		private void downHeap(int posicao = 0)
		{
			if (proximoElemento > 1)
			{
				int limite = (proximoElemento - 1) / 2;
				Aresta aux;
				int filho;
				while (posicao <= limite)
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
		public void Add(Aresta aresta)
		{
			this.expandirArestas();
			arestas[proximoElemento] = aresta;
			this.upHeap(proximoElemento);
			this.atualizarMaiorPeso(aresta.peso);
			proximoElemento++;
		}

		/*O(1)*/
		public Aresta Top()
		{
			if (proximoElemento == 0)
				throw new HeapException("A Heap está vazia");
			return arestas[0];
		}

		/*O(log(n))*/
		public Aresta Remove()
		{
			if (proximoElemento == 0)
				throw new HeapException("A Heap está vazia");
			Aresta retorno = arestas[0];
			arestas[0] = arestas[--proximoElemento];
			if (proximoElemento == 0) /*Como eu removo sempre a aresta de menor peso, o maior peso será o ultimo a sair.*/
				maiorPeso = int.MinValue;
			this.downHeap();
			return retorno;
		}

		/*O(n)*/
		public void Remove(Aresta aresta)
		{
			if (proximoElemento-- == 0)
				throw new HeapException("A Heap está vazia");
			int posicao = 0;
			for (; posicao <= proximoElemento; posicao++)
				if (arestas[posicao].Equals(aresta))
					break;
			if (posicao > proximoElemento)
				throw new HeapException("Elemento não encontrado");
			if (proximoElemento != 0)
			{
				arestas[posicao] = arestas[proximoElemento];
				if (arestas[posicao].peso > aresta.peso)
					downHeap(posicao);
				else if (arestas[posicao].peso < aresta.peso)
					upHeap(posicao);

				if (maiorPeso == aresta.peso)
				{
					maiorPeso = int.MinValue;
					foreach (Aresta a in arestas)
						if (a.peso > maiorPeso)
							maiorPeso = a.peso;
				}
			}
		}

		/*O(n*log(n))*/
		public void removerMaioresQue(int peso)
		{
			if (proximoElemento != 0 && peso <= maiorPeso)
			{
				int i = 0;
				maiorPeso = int.MinValue;
				Aresta[] arestasAux = new Aresta[tamanho];
				while(this.Top().peso < peso)
				{
					this.atualizarMaiorPeso(this.Top().peso);
					arestasAux[i++] = this.Remove();
				}
				proximoElemento = i;
				arestas = arestasAux;
			}
		}

		/*O(n)*/
		public Aresta[] ToArray()
		{
			Aresta[] retorno = new Aresta[proximoElemento];
			for (int i = 0; i < proximoElemento; i++)
				retorno[i] = arestas[i];
			return retorno;
		}

		/*O(1)*/
		public int Count()
		{
			return proximoElemento;
		}

		public Heap Clone()
		{
			Heap heap = new Heap();
			heap.arestas = ((Aresta[])this.arestas.Clone());
			heap.tamanho = this.tamanho;
			heap.proximoElemento = this.proximoElemento;
			heap.maiorPeso = this.maiorPeso;
			return heap;
		}
	}
}

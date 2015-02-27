using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoSimples
{
	class ArestaComposta : Aresta
	{
		public List<Aresta> caminho { get; set; }

		public ArestaComposta()
		{
			peso = int.MaxValue;
		}

		public ArestaComposta(Vertice origemAresta, Vertice destinoAresta, Aresta arestaSimples)
		{
			peso = arestaSimples.peso;
			origem = origemAresta;
			destino = destinoAresta;
			caminho = new List<Aresta>();
			caminho.Add(arestaSimples);
		}

		public ArestaComposta(Vertice origem, Vertice destino, int peso = int.MaxValue, Aresta aresta = null)
			: base(origem, destino, peso)
		{
			this.peso = peso;
			this.origem = origem;
			this.destino = destino;
			this.caminho = new List<Aresta>();
			if (aresta != null && aresta.GetType().Equals(this)) //se for uma aresta composta
				this.caminho = ((ArestaComposta)aresta).caminho;
			else if (aresta != null)
			{
				caminho.Add(aresta);
			}
		}
	}
}

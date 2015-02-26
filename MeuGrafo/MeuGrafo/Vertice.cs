using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuGrafo
{
	public class Vertice
	{
		public Object valor { get; set; }
		public List<Aresta> arestas { get; set; }
		public int visitado { get; set; }

		public Vertice(Object valor)
		{
			this.valor = valor;
			arestas = new List<Aresta>();
			visitado = int.MinValue;
		}

		//Retorna true se vertice1 e vertice2 forem adjacentes
		public bool adjacente(Vertice vertice)
		{
			foreach (var aresta in arestas)
				if (aresta.destino.Equals(vertice) || aresta.origem.Equals(vertice))
					return true;
			return false;
		}

		//Retorna uma lista com todos os vertices adjacentes a ele
		public List<Vertice> verticesAdjacentes()
		{
			List<Vertice> verticesAdj = new List<Vertice>();
			foreach (var aresta in arestas)
				if(!verticesAdj.Contains(aresta.verticeOposto(this)))
					verticesAdj.Add(aresta.verticeOposto(this));
			return verticesAdj;
		}
	}
}

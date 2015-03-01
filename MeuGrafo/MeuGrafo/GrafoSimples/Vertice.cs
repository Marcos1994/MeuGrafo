using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoSimples
{
	public class Vertice
	{
		public Object valor { get; set; }
		public Heap arestas { get; set; }
		public int visitado { get; set; }

		public Vertice(Object valor)
		{
			this.valor = valor;
			arestas = new Heap();
			visitado = int.MinValue;
		}

		/*O(n)*/
		public bool adjacente(Vertice vertice)
		{
			Aresta[] aux = arestas.ToArray();
			foreach (var aresta in aux)
				if (aresta.destino.Equals(vertice) || aresta.origem.Equals(vertice))
					return true;
			return false;
		}

		/*O(n)*/
		//public Vertice[] verticesAdjacentes()
		//{
		//	Aresta[] arrayArestas = arestas.toArray();
		//	List<Vertice> vertices = new List<Vertice>();
		//	foreach (var aresta in arrayArestas)
		//		if (aresta.verticeOposto(this) && !vertices.Contains(aresta.verticeOposto(this)))
		//			vertices.Add(aresta.verticeOposto(this));
		//	return vertices.ToArray();
		//}
	}
}

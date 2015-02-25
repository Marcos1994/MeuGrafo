using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
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
	}
}

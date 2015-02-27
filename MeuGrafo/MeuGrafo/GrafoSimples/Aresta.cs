using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoSimples
{
	public class Aresta
	{
		public int peso { get; set; }
		public Vertice origem { get; set; }
		public Vertice destino { get; set; }
		public int visitado { get; set; }

		public Aresta()
		{
			peso = -1;
			visitado = int.MinValue;
		}

		public Aresta(Vertice origem, Vertice destino, int peso = 0)
		{
			this.peso = peso;
			this.origem = origem;
			this.destino = destino;
			visitado = int.MinValue;
		}

		//Retorna o vertice oposto ao vertice passado com base na aresta
		public Vertice verticeOposto(Vertice verticeInicial)
		{
			if (destino.Equals(verticeInicial)) return origem;
			if (origem.Equals(verticeInicial)) return destino;
			throw new GrafoException();
		}
	}
}

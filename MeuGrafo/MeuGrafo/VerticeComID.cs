using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrafoSimples;

namespace MeuGrafo
{
	class VerticeComID : Vertice
	{
		public int id { get; set; }

		public VerticeComID(Object valor, int id)
			: base(valor)
		{
			this.id = id;
		}
	}
}

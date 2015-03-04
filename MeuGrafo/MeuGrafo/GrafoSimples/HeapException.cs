using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoSimples
{
	class HeapException : Exception
	{
		public HeapException()
			: base("Ocorreu algum erro")
		{
		}
		public HeapException(string msg)
			: base(msg)
		{
		}
	}
}

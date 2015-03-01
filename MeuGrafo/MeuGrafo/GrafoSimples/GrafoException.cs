﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoSimples
{
	class GrafoException : Exception
	{
		public GrafoException()
			: base("Ocorreu algum erro")
		{
		}

		public GrafoException(string msg)
			: base(msg)
		{
		}
	}
}

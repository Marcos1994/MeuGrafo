using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MeuGrafo;
using GrafoWebService.NS_GrafoDAO;

namespace GrafoWebService.NS_GrafoPlus
{
	public class GrafoPlus : Grafo
	{
		public int idGrafo { get; set; }
		public string nome { get; set; }
		public int width { get; set; }
		public int height { get; set; }

		public GrafoPlus(string nome)
		{
			this.nome = nome;
			this.width = 500;
			this.height = 500;
		}

		//Salva o grafo no banco
		public void criarGrafo()
		{
			GrafoDAO dao = new GrafoDAO();
			try
			{
				dao.criarGrafo(this.nome, this.width, this.height);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}
}
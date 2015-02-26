using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrafoWebService;

namespace GrafoWebService.NS_GrafoDAO
{
	public class GrafoDAO
	{
		internal void criarGrafo(string nome, int width, int height)
		{
			GrafoLinqDataContext dt = new GrafoLinqDataContext();
			tb_Grafo novoGrafo = new tb_Grafo();
			novoGrafo.nome = nome;
			novoGrafo.width = width;
			novoGrafo.height = height;
			dt.tb_Grafos.InsertOnSubmit(novoGrafo);
			try
			{
				dt.SubmitChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
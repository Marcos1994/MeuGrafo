using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrafoWebService.NS_GrafoPlus;

namespace GrafoWebService.NS_GrafoDAO
{
	public class VerticeDAO
	{
		public void criarVertice(int idGrafo, string valor, int posX, int posY)
		{
			GrafoLinqDataContext dt = new GrafoLinqDataContext();
			tb_Vertice novoVertice = new tb_Vertice();
			novoVertice.id_grafo = idGrafo;
			novoVertice.nome = valor;
			novoVertice.posX = posX;
			novoVertice.posY = posY;
			dt.tb_Vertices.InsertOnSubmit(novoVertice);
			dt.SubmitChanges();
		}
	}
}
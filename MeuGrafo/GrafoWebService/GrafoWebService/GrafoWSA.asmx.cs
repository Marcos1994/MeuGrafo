using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using GrafoWebService.NS_GrafoPlus;

namespace GrafoWebService.GrafoWebService
{
	/// <summary>
	/// Summary description for WebService1
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class GrafoWSA : System.Web.Services.WebService
	{

		/*_________ Grafo _________*/

		[WebMethod]
		public string criarGrafo(string nome)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			GrafoPlus grafo;
			try
			{
				grafo = new GrafoPlus(nome);
				grafo.criarGrafo();
			}
			catch(Exception ex)
			{
				return js.Serialize(new GrafoWSErro(ex));
			}
			return js.Serialize(new Retorno());
		}

		[WebMethod]
		public string salvarGrafo(int idGrafo, string posicoesVertices)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize((new GrafoWSErro()).mensagem = "Metodo não implementado");
		}

		[WebMethod]
		public string abrirGrafo(string nomeGrafo)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			GrafoPlus grafo;
			try
			{
				grafo = new GrafoPlus(nomeGrafo);
				grafo.abrirGrafoPlus();
			}
			catch (Exception ex)
			{
				return js.Serialize(new GrafoWSErro(ex));
			}
			return js.Serialize(grafo);
		}



		/*_________ Vertices _________*/

		[WebMethod]
		public string criarVertice(int idGrafo)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize(new Retorno());
		}

		[WebMethod]
		public string removerVertice(int idVertice)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize(new Retorno());
		}

		[WebMethod]
		public string alterarValor(int idVertice, string valor)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize(new Retorno());
		}



		/*_________ Arestas _________*/

		[WebMethod]
		public string criarAresta(int idOrigem, int idDestino, int peso)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize(new Retorno());
		}

		[WebMethod]
		public string removerAresta(int idAresta)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize(new Retorno());
		}

		[WebMethod]
		public string alterarPeso(int idAresta, string valor)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize(new Retorno());
		}



		/*_________ Buscas _________*/

		[WebMethod]
		public string menorCaminho(string nome, int idOrigem, int idDestino)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			GrafoPlus grafo;
			try
			{
				grafo = new GrafoPlus(nome);
				grafo.abrirGrafo();
			}
			catch (Exception ex)
			{
				return js.Serialize(new GrafoWSErro(ex));
			}
			return js.Serialize(grafo);
		}
	}
}

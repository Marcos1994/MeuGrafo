using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

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
	public class WebService1 : System.Web.Services.WebService
	{

		/*_________ Grafo _________*/

		[WebMethod]
		public string criarGrafo()
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize(new Retorno());
		}

		[WebMethod]
		public string salvarGrafo(int idGrafo, string posicoesVertices)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize(new Retorno());
		}

		[WebMethod]
		public string abrirGrafo(string nomeGrafo)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize(new Retorno());
		}



		/*_________ Vertices _________*/

		[WebMethod]
		public string criarVertice(string nome)
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
	}
}

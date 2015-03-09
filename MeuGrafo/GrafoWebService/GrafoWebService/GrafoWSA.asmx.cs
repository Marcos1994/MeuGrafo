using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using GrafoWebService.NS_GrafoPlus;
using GrafoWebService.NS_GrafoDTO;

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

		[WebMethod] /*OK*/
		public string criarGrafo(string nome)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			GrafoPlus grafo;
			try
			{
				grafo = new GrafoPlus(nome);
				grafo.criarGrafo();
				GrafoDTO grafoDTO = grafo.gerarDTO();
				return js.Serialize(new RetornoComposto(grafoDTO));
			}
			catch(Exception ex)
			{
				return js.Serialize(new GrafoWSErro(ex));
			}
		}

		[WebMethod]
		public string salvarGrafo(string vertices)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize((new GrafoWSErro()).mensagem = "Metodo não implementado");
		}

		[WebMethod] /*OK*/
		public string alterarDimensoes(string nomeGrafo, int width, int height)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			GrafoPlus grafo;
			try
			{
				grafo = new GrafoPlus(nomeGrafo);
				grafo.abrirGrafo();
				grafo.salvarDimensoes();
				GrafoDTO grafoDTO = grafo.gerarDTO();
				return js.Serialize(new RetornoComposto(grafoDTO));
			}
			catch (Exception ex)
			{
				return js.Serialize(new GrafoWSErro(ex));
			}
		}

		[WebMethod] /*OK*/
		public string abrirGrafo(string nomeGrafo)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			try
			{
				GrafoPlus grafo;
				grafo = new GrafoPlus(nomeGrafo);
				grafo.abrirGrafo();
				GrafoDTO grafoDTO = grafo.gerarDTO();

				return js.Serialize(grafoDTO);
			}
			catch (Exception ex)
			{
				return js.Serialize(new GrafoWSErro(ex));
			}
		}



		/*_________ Vertices _________*/

		[WebMethod] /*OK*/
		public string criarVertice(int idGrafo, string valorVertice, int posX, int posY)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			VerticePlus vertice = new VerticePlus(valorVertice, posX, posY);
			try
			{
				vertice.criarVertice(idGrafo);
				VerticeDTO verticeDTO = vertice.gerarDTO();
				return js.Serialize(new RetornoComposto(verticeDTO));
			}
			catch (Exception ex)
			{
				return js.Serialize(new GrafoWSErro(ex));
			}
		}

		[WebMethod]
		public string removerVertice(int idVertice)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize((new GrafoWSErro()).mensagem = "Metodo não implementado");
		}

		[WebMethod]
		public string alterarValor(int idVertice, string valor)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize((new GrafoWSErro()).mensagem = "Metodo não implementado");
		}



		/*_________ Arestas _________*/

		[WebMethod] /*OK*/
		public string criarAresta(int idOrigem, int idDestino, int peso)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			ArestaPlus aresta = new ArestaPlus(peso, idOrigem, idDestino);
			try
			{
				aresta.criarAresta();
				ArestaDTO arestaDTO = aresta.gerarDTO();
				return js.Serialize(new RetornoComposto(arestaDTO));
			}
			catch (Exception ex)
			{
				return js.Serialize(new GrafoWSErro(ex));
			}
		}

		[WebMethod]
		public string removerAresta(int idAresta)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize((new GrafoWSErro()).mensagem = "Metodo não implementado");
		}

		[WebMethod]
		public string alterarPeso(int idAresta, string valor)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize((new GrafoWSErro()).mensagem = "Metodo não implementado");
		}



		/*_________ Buscas _________*/

		[WebMethod]
		public string menorCaminho(string nome, int idOrigem, int idDestino)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize((new GrafoWSErro()).mensagem = "Metodo não implementado");
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

		[WebMethod]
		public string menorCaminhoEstrela(string nome, int idOrigem, string chaveDestino)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize((new GrafoWSErro()).mensagem = "Metodo não implementado");
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

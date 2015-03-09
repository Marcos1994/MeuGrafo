﻿using System;
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

		[WebMethod]
		public string alterarDimensoes(int width, int height)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			return js.Serialize((new GrafoWSErro()).mensagem = "Metodo não implementado");
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

		[WebMethod]
		public string criarVertice(int idGrafo, string valorVertice)
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

		[WebMethod]
		public string menorCaminhoEstrela(string nome, int idOrigem, string chaveDestino)
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

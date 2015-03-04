using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrafoSimples;

namespace MeuGrafo
{
	class Program
	{
		private static int width = 0;
		private static int height = 0;
		private static int[,] labirinto;
		private static string labirintoString;
		private static string valor = "";
		private static Grafo grafo;
		private static int indiceGrafo = 0;

		static void Main(string[] args)
		{
			string diretorio = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string[] dr = diretorio.Split('\\');
			diretorio = "";
			for (int i = 0; i < dr.Count() - 3; i++)
				diretorio += dr[i] + "\\";
			Console.WriteLine("Informe o nome do arquivo (sem extensão) que deseja abrir:");
			Console.WriteLine("Diretório padrão: MeuGrafo\\labirintos");
			diretorio += Console.ReadLine() + ".dat";
			try
			{
				FileInfo arquivo = new FileInfo(diretorio);
				FileStream fs = arquivo.Open(FileMode.Open, FileAccess.Read);
				StreamReader r = new StreamReader(fs);
				string trecho = r.ReadToEnd();
				string[] tr = trecho.Split('\r');
				labirintoString = "";
				for (int i = 0; i < tr.Count(); i++)
					foreach (char t in tr[i])
						if (t == '0' || t == '1' || t == '2' || t == '3') labirintoString += t;
				height = tr.Count();
				if (height > 0) width = tr[0].Count();
				Console.Clear();
			}
			catch
			{
				Console.Clear();
				Console.WriteLine("Não foi possivel abrir o arquivo desejado\nlabirinto padrão:");
				width = 10; height = 12;
				labirintoString = "111111111110000000011200010101111101010110000001011011111103100000000111111111013100100001110100111110000003011111111111";
			}

			if (width > 1 && height > 1)
			{
				grafo = new Grafo();
				Console.WriteLine("Labirinto:");
				gerarLabirintoInicial();
				escreverLabirinto();
				Console.ReadKey();
				Console.BackgroundColor = ConsoleColor.Black;
				Console.Clear();
				gerarGrafo();
				gerarSolucao();
				Console.WriteLine("Solucao");
				escreverLabirinto();
			}
			else
				Console.WriteLine("O labirinto exibito tem menos de 1 linha ou menos de 1 coluna!");
			Console.ReadKey();
		}

		private static void escreverLabirinto()
		{
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					valor = labirinto[i, j].ToString();
					switch (valor)
					{
						case "0":
							Console.BackgroundColor = ConsoleColor.White;
							break;
						case "1":
							Console.BackgroundColor = ConsoleColor.Gray;
							break;
						case "2":
							Console.BackgroundColor = ConsoleColor.Blue;
							break;
						case "3":
							Console.BackgroundColor = ConsoleColor.Red;
							break;
						case "4":
							Console.BackgroundColor = ConsoleColor.Green;
							break;
						default:
							Console.BackgroundColor = ConsoleColor.DarkYellow;
							break;
					}
					Console.Write(" ");
				}
				Console.WriteLine();
			}
		}

		private static void gerarLabirintoInicial()
		{
			labirinto = new int[height, width];
			for (int i = 0; i < labirintoString.Length; i++)
			{
				if (labirintoString.Substring(i, 1) != "1")
					grafo.vertices.Add(new VerticeComID(labirintoString.Substring(i, 1), i));
				labirinto[(i / width), (i % width)] = int.Parse(labirintoString.Substring(i, 1));
			}
		}

		private static void gerarGrafo()
		{
			Vertice vertice, verticeAux;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					vertice = grafo.vertices.Find(v => ((VerticeComID)v).id == (i * width + j));
					if (vertice != null && vertice.valor.ToString() != "1")
					{
						if (i + 1 < height)
						{
							verticeAux = grafo.vertices.Find(v => ((VerticeComID)v).id == ((i + 1) * width + j));
							if (verticeAux != null && verticeAux.valor.ToString() != "1")
								grafo.inserirAresta(vertice, verticeAux, 1);
						}
						if (j + 1 < width)
						{
							verticeAux = grafo.vertices.Find(v => ((VerticeComID)v).id == (i * width + j + 1));
							if (verticeAux != null && verticeAux.valor.ToString() != "1")
								grafo.inserirAresta(vertice, verticeAux, 1);
						}
					}
				}
			}
		}

		private static void gerarSolucao()
		{
			List<Aresta> menorCaminho = new List<Aresta>();
			VerticeComID origem = null;
			string destino = "3";
			for (int i = 0; i < labirintoString.Length; i++)
				if (labirinto[(i / width), (i % width)] == 2)
				{
					origem = ((VerticeComID)grafo.vertices.Find(v => ((VerticeComID)v).id == i));
					break;
				}
			if (origem != null)
			{
				VerticeComID dest;
				menorCaminho = grafo.menorCaminho(origem, destino);
				foreach (Aresta aresta in menorCaminho)
				{
					origem = ((VerticeComID)aresta.origem);
					labirinto[(origem.id / width), (origem.id % width)] = 4;
					dest = ((VerticeComID)aresta.destino);
					labirinto[(dest.id / width), (dest.id % width)] = 4;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuGrafo
{
	class Program
	{
		private static int width = 10;
		private static int height = 12;
		private static int[,] labirinto;
		private static string labirintoString = "111111111110000000011200010101111101010110000001011011111101100000000111111111011100100001110100111110000003011111111111";
		private static string valor = "";
		private static Grafo grafo;

		static void Main(string[] args)
		{
			grafo = new Grafo();
			Console.WriteLine("Labirinto:");
			gerarLabirintoInicial();
			escreverLabirinto();
			Console.ReadKey();
			Console.BackgroundColor = ConsoleColor.Black;
			//Console.Clear();
			gerarGrafo();
			gerarSolucao();
			Console.WriteLine("Solucao");
			escreverLabirinto();
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
					grafo.vertices.Add(new VerticeComID(valor, i));
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
			VerticeComID destino = null;
			for (int i = 0; i < labirintoString.Length; i++)
				if (labirinto[(i / width), (i % width)] == 2)
				{
					origem = ((VerticeComID)grafo.vertices.Find(v => ((VerticeComID)v).id == i));
					break;
				}
			for (int i = 0; i < labirintoString.Length; i++)
				if (labirinto[(i / width), (i % width)] == 3)
				{
					destino = ((VerticeComID)grafo.vertices.Find(v => ((VerticeComID)v).id == i));
					break;
				}
			if (origem != null && destino != null)
			{
				menorCaminho = grafo.menorCaminho(origem, destino);
				foreach (Aresta aresta in menorCaminho)
				{
					origem = ((VerticeComID)aresta.origem);
					labirinto[(origem.id / width), (origem.id % width)] = 4;
					destino = ((VerticeComID)aresta.destino);
					labirinto[(destino.id / width), (destino.id % width)] = 4;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuGrafo
{
	class Program
	{
		private static int width;
		private static int height;
		private static int[,] labirinto;
		private static string labirintoString;
		private static string valor = "";
		private static Grafo grafo;
		private static int indiceGrafo = 0;

		static void Main(string[] args)
		{
			do
			{
			selecionarGrafo();
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
			Console.ReadKey();
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Clear();
			} while(indiceGrafo < 3);
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

		private static void selecionarGrafo()
		{
			++indiceGrafo;
			switch (indiceGrafo)
			{
				case 1:
					width = 10; height = 12;
					labirintoString = "111111111110000000011200010101111101010110000001011011111101100000000111111111011100100001110100111110000003011111111111";
					break;
				case 2:
					width = 30; height = 15;
					labirintoString = "111111111111111111111111111111100000111000000010000010011111101110111101101000111110111111100010000001101110111100011111121110111011101110111111111111100000111011101100000111001111110110000000001111110010011111110110111111111100000000111111110110111111111111111000111111110000000000000011000000000111110111101111111011011011110111110111101111111011011011100011110111100000000311000001101111110000001111111000011100001111111111111111111111111111111111";
					break;
				default:
					width = 21; height = 8;
					labirintoString = "111111111111111111111120000000000011001001101111111101111000001101111111101111010101100011111101111011101101111111101111011101101111110000000011131111111111111111111111";
					break;
			}
			
		}
	}
}

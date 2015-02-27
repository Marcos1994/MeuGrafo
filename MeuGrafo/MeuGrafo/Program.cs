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
		private static string labirintoString = "111111111110000000011200010101111101010110000001011011111103100000000111111111013100100001110100111110000003011111111111";
		private static string opcao = "";
		private static string valor = "";
		private static Grafo grafo;

		static void Main(string[] args)
		{
			grafo = new Grafo();
			Console.WriteLine("Labirinto:");
			escreverLabirinto();
			Console.ReadKey();
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Clear();
			//aqui vai ser gerado o menor caminho para poder ser escrito
			Console.WriteLine("Solucao");
			escreverLabirinto();
			Console.ReadKey();
		}

		private static void escreverLabirinto()
		{
			gerarLabirintoInicial();
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
	}
}

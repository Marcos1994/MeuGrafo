using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuGrafo
{
	class Program
	{
		static void Main(string[] args)
		{
			int width = 10;
			int height = 12;
			int[,] labirinto = gerarLabirintoInicial();
			string opcao = "-1";
			string valor = "";
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
						default:
							Console.BackgroundColor = ConsoleColor.White;
							break;
					}
					Console.Write(" ");
				}
				Console.WriteLine();
			}
			Console.ReadKey();
		}

		private static int[,] gerarLabirintoInicial()
		{
			int[,] labirinto = new int[12, 10];
			string labirintoString = "111111111110000000011200010101111101010110000001011011111103100000000111111111013100100001110100111110000003011111111111";
			for (int i = 0; i < labirintoString.Length; i++)
				labirinto[(i / 10), (i % 10)] = int.Parse(labirintoString.Substring(i, 1));
			return labirinto;
		}
	}
}

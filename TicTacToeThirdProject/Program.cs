using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeThirdProject
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string[,] gameBoard = new string[3, 3];
            InitializeBoard(gameBoard);
            string currentPlayer = "X";
            int rowMove = 0;
            DisplayBoard(gameBoard);
            Console.Write("Row number 1 - 3");
            rowMove = Convert.ToInt32(Console.ReadLine());

        }

        private static void InitializeBoard(string[,] gameBoard)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameBoard[i, j] = " ";
                }
            }
        }

        private static void DisplayBoard(string[,] gameBoard)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(" ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ ");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                              " + gameBoard[i, 0] + "                             |                              " + gameBoard[i, 1] + "                             |                              " + gameBoard[i, 2] + "                             |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
                Console.WriteLine("|                                                            |                                                            |                                                            |");
            }

            Console.WriteLine(" ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ ");
        }
    }
}

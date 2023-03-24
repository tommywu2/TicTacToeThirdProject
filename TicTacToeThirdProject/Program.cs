using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
            string currentPlayer = "X";
            int rowMove = 0;
            int columnMove = 0;
            int moveCount = 0;
            bool gameEnd = false;
            char playAgain = ' ';
            int aiMove = 0;
            InitialiseGameBoard(gameBoard);
            DisplayBoard(gameBoard);
            while (true)
            {
                TakeTurn(gameBoard, ref currentPlayer, out rowMove, out columnMove, ref moveCount, ref gameEnd, ref playAgain, ref aiMove);
                DisplayBoard(gameBoard);
                for (int i = 0; i < 3; i++)
                {
                    //horizontal
                    if (gameBoard[i, 0] != " " && gameBoard[i, 0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2])
                    {
                        ChangePlayer(gameBoard, ref currentPlayer);
                        Console.WriteLine("Winner: " + currentPlayer);
                        gameEnd = true;
                        ChangePlayer(gameBoard, ref currentPlayer);

                    }
                    // vertical
                    if (gameBoard[0, i] != " " && gameBoard[0, i] == gameBoard[1, i] && gameBoard[1, i] == gameBoard[2, i])
                    {
                        ChangePlayer(gameBoard, ref currentPlayer);
                        Console.WriteLine("Winner: " + currentPlayer);
                        gameEnd = true;
                        ChangePlayer(gameBoard, ref currentPlayer);

                    }
                    // left diagonal
                    if (gameBoard[0, 0] != " " && gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2])
                    {
                        ChangePlayer(gameBoard, ref currentPlayer);
                        Console.WriteLine("Winner: " + currentPlayer);
                        gameEnd = true;
                        ChangePlayer(gameBoard, ref currentPlayer);

                    }
                    // right diagonal
                    if (gameBoard[0, 2] != " " && gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 0])
                    {
                        ChangePlayer(gameBoard, ref currentPlayer);
                        Console.WriteLine("Winner: " + currentPlayer);
                        gameEnd = true;
                        ChangePlayer(gameBoard, ref currentPlayer);

                    }
                }
            }

        }

        private static void TakeTurn(string[,] gameBoard, ref string currentPlayer, out int rowMove, out int columnMove, ref int moveCount, ref bool gameEnd, ref char playAgain, ref int aiMove)
        {
            if (moveCount > 8)
            {
                Console.WriteLine("Draw: No Winner");
                gameEnd = true;
            }
            if (gameEnd == true)
            {
                Console.WriteLine("Would you like to play again? Y/N");
                playAgain = Convert.ToChar(Console.ReadLine());
                if (playAgain != 'Y')
                {
                    
                }
                else
                {
                    aiMove = 0;
                    moveCount = 0;
                    currentPlayer = "X";
                    InitialiseGameBoard(gameBoard);
                    DisplayBoard(gameBoard);
                    gameEnd = false;

                }
            }
            
            if (currentPlayer == "O")
            {
                rowMove = 0;
                columnMove = 0;
                if (aiMove < 20)
                {
                    
                    AITurn(gameBoard, ref currentPlayer, out rowMove, out columnMove, ref moveCount, ref aiMove);

                }
                
            }
            else
            {
                Console.WriteLine("Current player: " + currentPlayer);
                Console.Write("Row number 1 - 3");
                rowMove = Convert.ToInt32(Console.ReadLine());
                if (rowMove > 3)
                {
                    Console.WriteLine("INVALID MOVE");
                    TakeTurn(gameBoard, ref currentPlayer, out rowMove, out columnMove, ref moveCount, ref gameEnd, ref playAgain, ref aiMove);
                }
                if (rowMove < 1)
                {
                    Console.WriteLine("INVALID MOVE");
                    TakeTurn(gameBoard, ref currentPlayer, out rowMove, out columnMove, ref moveCount, ref gameEnd, ref playAgain, ref aiMove);
                }
                Console.Write("Column number 1 - 3");
                columnMove = Convert.ToInt32(Console.ReadLine());
                if (columnMove > 3)
                {
                    Console.WriteLine("INVALID MOVE");
                    TakeTurn(gameBoard, ref currentPlayer, out rowMove, out columnMove, ref moveCount, ref gameEnd, ref playAgain, ref aiMove);
                }
                if (columnMove < 1)
                {
                    Console.WriteLine("INVALID MOVE");
                    TakeTurn(gameBoard, ref currentPlayer, out rowMove, out columnMove, ref moveCount, ref gameEnd, ref playAgain, ref aiMove);
                }
                if (gameBoard[rowMove - 1, columnMove - 1] == " ")
                {
                    gameBoard[rowMove - 1, columnMove - 1] = currentPlayer;
                    moveCount = moveCount + 1;
                    ChangePlayer(gameBoard, ref currentPlayer);
                }
                else
                {
                    Console.WriteLine("INVALID MOVE");
                    TakeTurn(gameBoard, ref currentPlayer, out rowMove, out columnMove, ref moveCount, ref gameEnd, ref playAgain, ref aiMove);
                }
            }
            

        }

        private static void InitialiseGameBoard(string[,] gameBoard)
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
                // makes the top of the board.
                for (int z = 0; z < 3; z++)
                {

                    Console.Write(" ");

                    for (int w = 0; w < 40; w++)
                    {

                        Console.Write("+");
                    }
                }
                Console.WriteLine(" ");

                //makes the diagonal lines.
                for (int o = 0; o < 8; o++)
                {
                    for (int g = 0; g < 3; g++)
                    {

                        Console.Write("|");

                        for (int w = 0; w < 40; w++)
                        {

                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine("|");
                }

                //makes where the x/o goes.
                Console.Write("|");

                for (int w = 0; w < 19; w++)
                {

                    Console.Write(" ");
                }
                Console.Write(gameBoard[i, 0]);
                for (int k = 0; k < 20; k++)
                {

                    Console.Write(" ");
                }
                Console.Write("|");

                for (int w = 0; w < 19; w++)
                {

                    Console.Write(" ");
                }
                Console.Write(gameBoard[i, 1]);
                for (int k = 0; k < 20; k++)
                {

                    Console.Write(" ");
                }
                Console.Write("|");

                for (int w = 0; w < 19; w++)
                {

                    Console.Write(" ");
                }
                Console.Write(gameBoard[i, 2]);
                for (int k = 0; k < 20; k++)
                {

                    Console.Write(" ");
                }
                Console.WriteLine("|");

                //makes the diagonal lines.
                for (int p = 0; p < 8; p++)
                {
                    for (int g = 0; g < 3; g++)
                    {

                        Console.Write("|");

                        for (int w = 0; w < 40; w++)
                        {

                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine("|");
                }
            }

            // makes the bottom of the board.
            for (int g = 0; g < 3; g++)
            {

                Console.Write(" ");

                for (int w = 0; w < 40; w++)
                {

                    Console.Write("+");
                }
            }
            Console.WriteLine(" ");

        }

        private static void ChangePlayer(string[,] gameBoard, ref string currentPlayer)
        {
            if (currentPlayer == "X")
            {
                currentPlayer = "O";
            }
            else
            {
                currentPlayer = "X";
            }
        }
        private static void AITurn(string[,] gameBoard, ref string currentPlayer, out int rowMove, out int columnMove, ref int moveCount, ref int aiMove)
        {
            rowMove = 0;
            columnMove = 0;
            if (currentPlayer == "O")
            {
                rowMove = new Random().Next(1, 4);
                columnMove = new Random().Next(1, 4);
                if (gameBoard[rowMove - 1, columnMove - 1] == " ")
                {
                    gameBoard[rowMove - 1, columnMove - 1] = currentPlayer;
                    moveCount = moveCount + 1;
                    ChangePlayer(gameBoard, ref currentPlayer);
                }
                else
                {
                    aiMove = aiMove + 1;
                    AITurn(gameBoard, ref currentPlayer, out rowMove, out columnMove, ref moveCount, ref aiMove);
                }

            }
            
        }

    }
}


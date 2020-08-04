using System;
using System.Threading;

namespace tictactoe
{
    internal class Program
    {
        static char[] arr = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'}; //board positions array
        static int player = 1; //id of current player (1 by default)
        static int choice; //varaible, consisting position number
        static int flag = 0; //game status flag
        //-1 - draw
        //0 - game running
        //1 - one of the players has won

        public static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1:X Player 2:O");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2 chance!");
                }
                else
                {
                    Console.WriteLine("Player 1 chance!");
                }

                Console.WriteLine("\n");
                getBoard(); //generating board
                choice = int.Parse(Console.ReadLine()); //getting current player choice
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, the position {0} already marked with {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Board loading...");
                    Thread.Sleep(2500);
                }

                flag = checkWin();
            } while (flag != 1 && flag != -1);

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won!", (player%2) + 1);
            }
            else
            {
                Console.WriteLine("Draw");
            }

            Console.ReadLine();
        }
        private static void getBoard() //board draw function
        {
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);

            Console.WriteLine("     |     |      ");
        }
       
        //check player winning
        private static int checkWin()
        {
            #region Horizontal Winning Condition
            //winning condition for first row
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //winning condition for second row
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //winning condition for third row
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            #endregion

            #region Vertical Winning Condition

            //winning condition for first row
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //winning condition for second row
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //winning condition for third row
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion

            #region Diagonal Winning Condition

            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion

            #region Draw Check

            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' &&
                     arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }

            #endregion

            else return 0;
        }
    }
}
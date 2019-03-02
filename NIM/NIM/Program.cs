using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIM
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        public static void StartGame(int sticks, int counter, string player1, string player2)
        {
            int sticksTake = 0;
            while (sticks > 0)
            {
                if (counter % 2 == 0)
                {
                    Console.WriteLine("Wie viele Stöcke willst Du nehmen? " + player1 + ":");
                    sticksTake = Convert.ToInt32(Console.ReadLine());
                    if (sticksTake >= 1 && sticksTake <= 3)
                    {
                        sticks = sticks - sticksTake;
                        counter += 1;
                        DrawSticks(sticks);
                    }
                    else
                    {
                        Console.WriteLine("Im Ernst? Nochmal bitte...");

                    }
                    
                }
                else if (counter % 2 != 0)
                {
                    Console.WriteLine("Wie viele Stöcke willst Du nehmen? " + player2 + ":");
                    sticksTake = Convert.ToInt32(Console.ReadLine());
                    if (sticksTake >= 1 && sticksTake <= 3)
                    {
                        sticks = sticks - sticksTake;
                        counter += 1;
                        DrawSticks(sticks);
                    }
                    else
                    {
                        Console.WriteLine("Im Ernst? Nochmal bitte...");
                    }
                }
            }
            if (counter % 2 != 0)
            {
                EndGame(player2);
            }
            else if (counter % 2 == 0)
            {
                EndGame(player1);
            }
        }

        public static void DrawSticks(int sticks)
        {
            for (int i = 0; i < sticks; i++)
            {
                Console.Write("|");
            }
            Console.WriteLine("");
        }

        public int Delete(int sticks, int take)
        {
            sticks = sticks - take;
            return sticks;
        }

        public static void Start()
        {
            String player1 = null;
            String player2 = null;
            int sticks;
            int counter = 1;
            Console.Title = "NIM";

            for (int i = 1; i < 3; i++)
            {
                Console.WriteLine("Wie heißt SpielerIn " + i + "?");
                if (i == 1)
                {
                    player1 = Console.ReadLine();
                }
                else
                {
                    player2 = Console.ReadLine();
                }
                Console.Clear();
            }
            Console.WriteLine("Hallo " + player1 + " und " + player2 + "!");
            Console.WriteLine("Alles klar. Auf gehts. Mit wie vielen Stöcken soll gespielt werden?");
            sticks = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Achtung! Es dürfen immer nur 1-3 Stöcke gezogen werden. Alles andere wäre ja unfair ;)");
            DrawSticks(sticks);
            StartGame(sticks, counter, player1, player2);
        }

        public static void EndGame(string winner)
        {
            Console.WriteLine("SpielerIn " + winner + " hat gewonnen!");
            Console.WriteLine("Wollt Ihr nochmal spielen? y/n");
            if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
            {
                Console.Clear();
                Start();
            }
            else if (Console.ReadLine() == "n" || Console.ReadLine() == "N")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe erkannt!");
            }
        }
    }
}
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ArenaFighter
{
    public class Arena
    {
        public static void Main(string[] args)
        {
            printHeaderClear("Arena Fighter - Wanna Fight?\n");
            
            Console.Write("Input your name\n> ");
            player = new Character(Console.ReadLine());
            player.setStats(30, 7, 5);

            bool show = true;
            while (show)
            {
                show = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            printHeaderClear("Arena Fighter - Main Menu\n");
            Console.Write(
                "1) Fight\n" +
                $"2) Experience ({player.Experience})\n" +
                "3) Log\n" +
                "0) Exit\n" +
                "> "
            );

            switch (Console.ReadLine())
            {
                case "0": handleExit(); return false;
                case "1": handleFight(); return true;
                case "2": handleExperience(); return true;
                case "3": handleLog(); return true;
                default: return true;
            }
        }

        private static void handleFight()
        {
            printHeaderClear("Arena Fighter - Fight\n");

            opponent = new Character(player, 4, -1);
            battles.Add(new Battle(ref player, ref opponent));

            if (!battles.Last().fight())
            {
                battles.Last().getLog.printEntries();

                Console.WriteLine("\nYou where defeated!");
                holdForInput("\n\tPress any key to exit...");
                handleExit();
            }

            battles.Last().getLog.printEntries();
            holdForInput("\n\tPress any key to return to main menu...");
        }

        private static void handleExperience()
        {
            printHeaderClear("Arena Fighter - Experience\n");

            WriteLine("Upgrade a statisic");
            Console.Write(
                "1) Health\n" +
                "2) Strength\n" +
                "3) Luck\n" +
                "0) Main menu\n" +
                "> "
            );

            switch (Console.ReadLine())
            {
                case "0": break;
                case "1": player.Health++; player.Experience--; break;
                case "2": player.Strength++; player.Experience--; break;
                case "3": player.Luck++; player.Experience--; break;
                default: break;
            }
        }

        private static void handleLog()
        {
            printHeaderClear("Arena Fighter - Log\n");

            for (int i = 0; i < battles.Count; i++)
            {
                battles[i].getLog.printEntries();
                Console.WriteLine("\n");
            }

            holdForInput("\n\tPress any key to return to main menu...");
        }

        private static void handleExit()
        {
            printHeaderClear("Arena Fighter - Exiting\n");

            int fights = battles.Count;
            int[] score = calculateScore();

            Console.WriteLine("You fought {0} rounds in {1} battles {3}, your score is {2}.\n", 
                score[1], fights, score[0], player.IsAlive ? "undefeated" : "and lost");
            Console.WriteLine("Battle Log:");
            for (int i = 0; i < fights; i++)
            {
                battles[i].getLog.printResult();
            }
            Console.WriteLine("\n\tGoodBye, come back soon.");
            
            holdForInput("\nPress any key to exit...");

            Environment.Exit(0);
        }

        private static int[] calculateScore()
        {
            int[] score = new int[2];
            int bc = battles.Count;

            for (int i = 0; i < bc; i++)
                score[1] += battles[i].getLog.count - 2;

            if (!player.IsAlive)
                score[0] = score[1] - (battles.Last().getLog.count - 2);
            else
                score[0] = score[1] + bc;

            return score;
        }

        private static void holdForInput(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadKey();
        }

        private static void printHeaderClear(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
        }

        private static Character player, opponent;
        private static List<Battle> battles = new List<Battle>();
    }
}

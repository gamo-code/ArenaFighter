using System;
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

            Write("Input your name\n> ");
            player = new Character(ReadLine());
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
            Write(
                "1) Fight\n" +
               $"2) Experience ({player.Experience})\n" +
                "3) Log\n" +
                "0) Exit\n" +
                "> "
            );

            switch (ReadLine())
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
                battles.Last().getLog.printLog();

                WriteLine("\nYou where defeated!");
                holdForInput("\n\tPress any key to exit...");
                handleExit();
            }

            battles.Last().getLog.printLog();
            holdForInput("\n\tPress any key to return to main menu...");
        }

        private static void handleExperience()
        {
            printHeaderClear("Arena Fighter - Experience\n");

            WriteLine("Upgrade a statisic");
            Write(
                "1) Health\n" +
                "2) Strength\n" +
                "3) Luck\n" +
                "0) Main menu\n" +
                "> "
            );

            switch (ReadLine())
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
                battles[i].getLog.printLog();
                WriteLine("\n");
            }

            holdForInput("\n\tPress any key to return to main menu...");
        }

        private static void handleExit()
        {
            printHeaderClear("Arena Fighter - Exiting\n");

            int bc = battles.Count;

            int rounds, score;
            calculateScore(out rounds, out score);

            WriteLine("You fought {0} rounds in {1} battles {3}, your score is {2}.\n",
                rounds, bc, score, player.IsAlive ? "undefeated" : "and lost");
            WriteLine("Battle Log:");
            for (int i = 0; i < bc; i++)
            {
                battles[i].getLog.printResult();
            }
            WriteLine("\n\tGoodBye, come back soon.");

            if (player.IsAlive)
            {

            }
            holdForInput("\nPress any key to exit...");

            Environment.Exit(0);
        }

        private static void calculateScore(out int rounds, out int score)
        {
            rounds = 0;
            score = 0;
            int bc = battles.Count;

            for (int i = 0; i < bc; i++)
                rounds += battles[i].getLog.count;

            if (!player.IsAlive)
                score = rounds - battles.Last().getLog.count;
            else
                score = rounds + bc;
        }

        private static void holdForInput(string msg)
        {
            WriteLine(msg);
            ReadKey();
        }

        private static void printHeaderClear(string msg)
        {
            Clear();
            WriteLine(msg);
        }

        private static Character player, opponent;
        private static List<Battle> battles = new List<Battle>();
    }
}

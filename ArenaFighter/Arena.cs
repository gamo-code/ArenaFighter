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
            Run();
        }

        private static void Run()
        {
            printHeaderClear("Arena Fighter - Wanna Fight?\n");

            Write("Input your name\n> ");
            player = new Character(ReadLine());
            player.setStats(30, 7, 5, 0, 0);

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
               $"3) Equipment ({player.Gold})\n" +
                "4) Log\n" +
                "0) Exit\n" +
                "> "
            );

            switch (ReadLine())
            {
                case "0": handleExit(); return false;
                case "1": handleFight(); return true;
                case "2": handleExperience(); return true;
                case "3": handleGold(); return true;
                case "4": handleLog(); return true;
                default: return true;
            }
        }

        private static void handleFight()
        {
            printHeaderClear("Arena Fighter - Fight\n");

            opponent = new Character(player, 5, -2);
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

            WriteLine($"Experience to spend: {player.Experience}\n");

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

        private static void handleGold()
        {
            printHeaderClear("Arena Fighter - Equipment\n");

            WriteLine($"Gold to spend: {player.Gold}\n");

            WriteLine("Buy Equipment");
            Write(
                "1) Weapon\n" +
                "2) Armor\n" +
                "0) Main menu\n" +
                "> "
            );

            switch (ReadLine())
            {
                case "0": break;
                case "1": player.Weapon++; player.Gold--; break;
                case "2": player.Armor++; player.Gold--; break;
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
            calculateScore(out rounds, out score); // uuugh. C# need multiple returns and deconstruction

            WriteLine("You fought {0} rounds in {1} battles {3}, your score is {2}.",
                rounds, bc, score, player.IsAlive ? "undefeated" : "and lost");

            WriteLine("\nFinal stats:");
            player.printStats();

            WriteLine("\nBattles fought:");
            printBattleResults();

            WriteLine("\n\tPress R to restart or any key to exit.");
            string restart = ReadKey().KeyChar.ToString();
            WriteLine(restart);
            if (restart == "r" || restart == "R")
                Run();

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

        private static string holdForInput(string msg)
        {
            WriteLine(msg);
            return ReadKey().ToString();
        }

        private static void printHeaderClear(string msg)
        {
            Clear();
            WriteLine(msg);
        }

        private static void printBattleResults()
        {
            if (battles.Count > 0)
            {
                
                foreach (Battle b in battles)
                    b.getLog.printResult();
            }
        }

        private static Character player, opponent;
        private static List<Battle> battles = new List<Battle>();
    }
}

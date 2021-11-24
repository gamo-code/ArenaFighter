using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ArenaFighter
{
    public class Log
    {
        public void printLog()
        {
            WriteLine(header);
            for (int i = 0; i < entries.Count; i++)
                WriteLine("Round {0}: {1}", i + 1, entries[i]);
            WriteLine(result);
        }

        public void printResult()
        {
            WriteLine(result);
        }

        public void addLogString(string format, params object[] args)
        {
            StringBuilder logString = new StringBuilder();
            entries.Add(logString.AppendFormat(format, args).ToString());
        }

        public void addLogHeader(Character c1, Character c2)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0,-15}  | {1}\n", c1.Name, c2.Name);
            sb.AppendFormat(" Health:   {0,4}  |  Health:   {1,4}\n", c1.Health, c2.Health);
            sb.AppendFormat(" Strength: {0,4}  |  Strength: {1,4}\n", c1.Strength, c2.Strength);
            sb.AppendFormat(" Luck:     {0,4}  |  Luck:     {1,4}", c1.Luck, c2.Luck);

            header = sb.ToString();
        }

        public void addResult(string format, params object[] args)
        {
            StringBuilder logString = new StringBuilder();
            result = logString.AppendFormat(format, args).ToString();
        }

        public int count { get => entries.Count; }

        private string header = "";
        private string result = "";
        private List<string> entries = new List<string>();
    }
}

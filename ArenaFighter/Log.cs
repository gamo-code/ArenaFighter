using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArenaFighter
{
    public class Log
    {
        public void add(string entry)
        {
            entries.Add(entry);
        }

        public void printEntries()
        {
            int i = 1;
            Console.WriteLine("{0}", entries[0]);
            for (; i < entries.Count - 1; i++)
            {
                Console.WriteLine("Round {0}: {1}", i, entries[i]);
            }
            Console.WriteLine("{0}", entries[i]);
        }

        public void printResult()
        {
            Console.WriteLine(entries.Last());
        }

        public void addLogString(string format, params object[] args)
        {
            StringBuilder logString = new StringBuilder();
            add(logString.AppendFormat(format, args).ToString());
        }

        public void addLogHeader(Character c1, Character c2)
        {
            StringBuilder header = new StringBuilder();

            header.AppendFormat("{0,-15}  | {1}\n", c1.Name, c2.Name);
            header.AppendFormat(" Health:   {0,4}  |  Health:   {1,4}\n", c1.Health, c2.Health);
            header.AppendFormat(" Strength: {0,4}  |  Strength: {1,4}\n", c1.Strength, c2.Strength);
            header.AppendFormat(" Luck:     {0,4}  |  Luck:     {1,4}", c1.Luck, c2.Luck);

            add(header.ToString());
        }

        public int count { get => entries.Count; }

        private List<string> entries = new List<string>();
    }
}

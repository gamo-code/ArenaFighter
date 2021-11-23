using System;

namespace ArenaFighter
{
    public class Character
    {
        public Character(string name)
        {
            Name = name;
            generateStats();
        }

        public Character(Character c = null, int spread = 3, int difficulty = 0)
        {
            generateName();
            generateStats(c, spread, difficulty);
        }

        private void generateStats(Character op = null, int spread = 3, int difficulty = 1)
        {

            int modl = spread - difficulty;
            int modh = spread + difficulty;
            modl = modl < 0 ? 0 : modl;
            modh = modh < 0 ? 0 : modh;

            if (op == null)
            {
                Health = randomNormal(10, 20, true);
                Strength = randomNormal(3, 5, true);
                Luck = randomNormal(1, 3, true);
            }
            else
            { 
                Health = randomNormal(op.Health - modl, op.Health + modh, true);
                Strength = randomNormal(op.Strength - modl, op.Strength + modh, true);
                Luck = randomNormal(op.Luck - modl, op.Luck + modh, true);
            }
        }

        public void setStats(int health, int strength, int luck)
        {
            Health = (health < 0 ? Health : health);
            Strength = (strength < 0 ? Strength : strength);
            Luck = (luck < 0 ? Luck : luck);
        }

        private void generateName(int nmin = 5, int nmax = 10)
        {
            string name = "";
            string vowels = "aouei";
            string consonants = "bcdfghjklmnpqrstvwxyz";

            int nlen = random.Next(nmin, nmax);
            name += vowels[random.Next(vowels.Length)].ToString().ToUpper();
            for (int j = 0; j < nlen - 1; j++)
            {
                if (j % 2 != 0)
                    name += vowels[random.Next(vowels.Length)];
                else
                    name += consonants[random.Next(consonants.Length)];
            }

            Name = name;
        }

        public static int randomNormal(int min, int max, bool safe = false)
        {
            int r = Convert.ToInt32((random.NextDouble() + random.NextDouble()) / 2 * (max - min)) + min;
            r = safe ? (r < 0 ? 1 : r) : r;
            return r;
        }

        public string Name { get => name;  set => name = value; }
        public int Health { get => stats.health; set => stats.health = value; }
        public int Strength { get => stats.strength; set => stats.strength = value; }
        public int Luck { get => stats.luck; set => stats.luck = value; }
        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        private string name;
        private Stats stats;
        private static readonly Random random = new Random();

        public struct Stats
        {
            public int health;
            public int strength;
            public int luck;
        }
    }
}
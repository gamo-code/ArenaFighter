using static ArenaFighter.Dice;
using static System.Console;

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
            modl = modl < 0 ? 1 : modl;
            modh = modh < 0 ? 1 : modh;

            if (op == null)
            {
                Health = RandomNonUniform(10, 20, true);
                Strength = RandomNonUniform(3, 5, true);
                Luck = RandomNonUniform(1, 3, true);
                Armor = 0;
                Weapon = 0;
                Experience = 0;
                Gold = 0;
            }
            else
            {
                Health = RandomNonUniform(op.Health - modl, op.Health + modh, true);
                Strength = RandomNonUniform(op.Strength - modl, op.Strength + modh, true);
                Luck = RandomNonUniform(op.Luck - modl, op.Luck + modh, true);
                Armor = RandomNonUniform(op.Armor - modl, op.Armor + modh, true);
                Weapon = RandomNonUniform(op.Weapon - modl, op.Weapon + modh, true);
                Experience = 0;
                Gold = 0;
            }
        }

        public void setStats(int health, int strength, int luck, int weapon, int armor)
        {
            Health = (health < 0 ? Health : health);
            Strength = (strength < 0 ? Strength : strength);
            Luck = (luck < 0 ? Luck : luck);
            Weapon = (weapon < 0 ? Luck : weapon);
            Armor = (armor < 0 ? Luck : armor);
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

        public void printStats()
        {
            WriteLine(
                "Health: {0}\n" +
                "Strength: {1}\n" +
                "Luck: {2}\n" +
                "Weapon: {3}\n" +
                "Armor: {4}\n" +
                "Gold: {5} (earned: {6})\n" +
                "Experience: {7} (earned: {8})",
                Health, Strength, Luck, Weapon, Armor,
                Gold, GoldTotal, Experience, ExperienceTotal
                );
        }

        public string Name { get => name; set => name = value; }
        public int Health { get => stats.health; set => stats.health = value; }
        public int Strength { get => stats.strength; set => stats.strength = value; }
        public int Luck { get => stats.luck; set => stats.luck = value; }
        public int Experience { get => stats.experience; set => stats.experience = value; }
        public int Gold { get => stats.gold; set => stats.gold = value; }
        public int ExperienceTotal { get => stats.experienceTot; set => stats.experienceTot = value; }
        public int GoldTotal { get => stats.goldTot; set => stats.goldTot = value; }
        public int Armor { get => stats.armor; set => stats.armor = value; }
        public int Weapon { get => stats.weapon; set => stats.weapon = value; }
        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        private string name;
        private Stats stats;

        public struct Stats
        {
            public int health;
            public int strength;
            public int luck;
            public int armor;
            public int weapon;
            public int experience;
            public int experienceTot;
            public int gold;
            public int goldTot;
        }
    }
}
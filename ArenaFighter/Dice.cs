using System;

namespace ArenaFighter
{
    public class Dice
    {
        public Dice(int sides = 6)
        {
            Sides = sides;
        }

        public int Roll()
        {
            return random.Next(0, Sides) + 1;
        }

        public static int Roll(int sides)
        {
            return random.Next(0, sides) + 1;
        }

        public int Sides
        {
            get { return sides; }
            private set { sides = value; }
        }

        public static int randomNormal(int min, int max, bool safe = false)
        {
            int r = Convert.ToInt32((random.NextDouble() + random.NextDouble()) / 2 * (max - min)) + min;
            r = safe ? (r < 0 ? 0 : r) : r;
            return r;
        }

        private int sides;
        public static readonly Random random = new Random();
    }
}

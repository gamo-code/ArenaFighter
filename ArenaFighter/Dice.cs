using System;

namespace ArenaFighter
{
    public class Dice
    {
        public static int Roll(int sides)
        {
            return random.Next(0, sides) + 1;
        }

        public static int RandomNonUniform(int min, int max, bool safe = false)
        {
            int r = Convert.ToInt32((random.NextDouble() + random.NextDouble()) / 2 * (max - min)) + min;
            r = safe ? (r < 0 ? 0 : r) : r;
            return r;
        }

        public static readonly Random random = new Random();
    }
}

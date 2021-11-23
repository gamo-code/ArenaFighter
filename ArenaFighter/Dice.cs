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

        private int sides;
        private static readonly Random random = new Random();
    }
}

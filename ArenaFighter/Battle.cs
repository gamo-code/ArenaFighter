using static ArenaFighter.Round;
using static ArenaFighter.Dice;

namespace ArenaFighter
{
    public class Battle
    {
        public Battle(ref Character player, ref Character opponent)
        {
            this.player = player;
            this.opponent = opponent;
            log = new Log();
            log.addLogHeader(player, opponent);
        }

        public bool fight()
        {
            int playerHealth = player.Health;
            int tmp;

            while (round(ref player, ref opponent, ref log)) { }
            
            if (player.IsAlive)
            {
                player.Health = playerHealth;
                tmp = Roll(2) - 1;
                player.Experience += tmp;
                player.ExperienceTotal += tmp;
                tmp = Roll(2) - 1;
                player.Gold += tmp;
                player.GoldTotal += tmp;
                return true;
            }
            return false;
        }

        public Log getLog { get => log; }

        private Character player, opponent;
        private Log log;
    }
}

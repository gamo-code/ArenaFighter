using static ArenaFighter.Round;

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

            while (round(ref player, ref opponent, ref log)) { }
            
            if (player.IsAlive)
            {
                player.Health = playerHealth;
                player.Experience += 1;
                player.Gold += 1;
                player.ExperienceTotal += 1;
                player.GoldTotal += 1;
                return true;
            }
            return false;
        }

        public Log getLog { get => log; }

        private Character player, opponent;
        private Log log;
    }
}

using System.Text;

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

            while (Round.fight(ref player, ref opponent, ref log));

            if ((log.count) % 2 == 0)
                Round.swapCharacter(ref player, ref opponent);

            if (player.IsAlive)
            {
                player.Health = playerHealth;
                player.Experience += 1;
                return true;
            }
            return false;
        }

        public Log getLog { get => log; }

        private Character player, opponent;
        private Log log;
    }
}

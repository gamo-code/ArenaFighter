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
            log.addLogHeadder(player, opponent);
        }

        public bool fight()
        {
            int playerHealth = player.Health;

            while (Round.fight(ref player, ref opponent, ref log) == true);

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

        private void addLogHeadder()
        {
            StringBuilder header = new StringBuilder();

            header.AppendFormat("{0,-15}  | {1}\n", player.Name, opponent.Name);
            header.AppendFormat(" Health:   {0,4}  |  Health:   {1,4}\n", player.Health, opponent.Health);
            header.AppendFormat(" Strength: {0,4}  |  Strength: {1,4}\n", player.Strength, opponent.Strength);
            header.AppendFormat(" Luck:     {0,4}  |  Luck:     {1,4}", player.Luck, opponent.Luck);

            log.add(header.ToString());
        }

        public Log getLog { get => log; }

        private Character player, opponent;
        private Log log;
    }
}

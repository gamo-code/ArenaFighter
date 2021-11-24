using System.Text;

namespace ArenaFighter
{
    public static class Round
    {
        public static bool round(ref Character def, ref Character att, ref Log log)
        {
            if(log.count % 2 == 0)
                swapCharacter(ref att, ref def);

            int damage = att.Strength + Dice.Roll(att.Luck) - Dice.Roll(def.Luck);
            def.Health -= damage;

            log.addLogString("{0} HITS {1} and does {2} damage => {1} has {3} health left.",
                att.Name, def.Name, damage, def.Health);

            if (def.Health < 1)
            {
                log.addLogString("{0} DEFEATED {1} after {2} rounds.",
                    att.Name, def.Name, log.count - 1);
                if (log.count % 2 == 0)
                    swapCharacter(ref att, ref def);
                return false;
            }

            if (log.count % 2 == 1)
                swapCharacter(ref att, ref def);

            return true;
        }

        private static void swapCharacter(ref Character def, ref Character att)
        {
            Character tmp = def;
            def = att;
            att = tmp;
        }
    }
}

using System.Text;

namespace ArenaFighter
{
    public static class Round
    {
        public static bool fight(ref Character def, ref Character att, ref Log log)
        {
            int damage = att.Strength + Dice.Roll(att.Luck) - Dice.Roll(def.Luck);
            def.Health -= damage;

            log.addLogString("{0} HITS {1} and does {2} damage => {1} has {3} health left.",
                att.Name, def.Name, damage, def.Health);

            if (def.Health < 1)
            {
                log.addLogString("{0} DEFEATED {1} after {2} rounds.",
                    att.Name, def.Name, log.count - 1);
                return false;
            }

            swapCharacter(ref att, ref def);

            return true;
        }

        public static void swapCharacter(ref Character def, ref Character att)
        {
            Character tmp = def;
            def = att;
            att = tmp;
        }
    }
}

using System.Collections.Generic;

namespace RoleplayGame
{
    public class SpellsBook: MagicalAttackDefenseItem
    {
        public List<Spell> Spells { get; set; } = new List<Spell>();
        public override int Attack
        {
            get
            {
                int value = 0;
                foreach (Spell spell in this.Spells)
                {
                    value += spell.AttackValue;
                }
                return value;
            }
        }

        public override int Defense
        {
            get
            {
                int value = 0;
                foreach (Spell spell in this.Spells)
                {
                    value += spell.DefenseValue;
                }
                return value;
            }
        }

        public void AddSpell(Spell spell)
        {
            this.Spells.Add(spell);
        }

        public void RemoveSpell(Spell spell)
        {
            this.Spells.Remove(spell);
        }
    }
}
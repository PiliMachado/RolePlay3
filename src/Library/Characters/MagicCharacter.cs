using System.Collections.Generic;
namespace RoleplayGame
{
    public class MagicCharacter: Character
    {
        private List<IMagicalItem> magicItems = new List<IMagicalItem>();
        public override int AttackValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.Items)
                {
                    if (item is AttackItem)
                    {
                        value += (item as AttackItem).Attack;
                    }
                }
                foreach (IMagicalItem item in this.magicItems)
                {
                    if (item is MagicalAttackItem)
                    {
                        value += (item as MagicalAttackItem).Attack;
                    }
                    else if (item is MagicalAttackDefenseItem)
                    {
                        value += (item as MagicalAttackDefenseItem).Attack;
                    }
                }
                return value;
            }
        }

        public override int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.Items)
                {
                    if (item is DefenseItem)
                    {
                        value += (item as DefenseItem).Defense;
                    }
                }
                foreach (IMagicalItem item in this.magicItems)
                {
                    if (item is MagicalDefenseItem)
                    {
                        value += (item as MagicalDefenseItem).Defense;
                    }
                }
                return value;
            }
        }
        public void AddItem(IMagicalItem item)
        {
            if(!this.magicItems.Contains(item))
            {
                this.magicItems.Add(item);
            }
        }

        public void RemoveItem(IMagicalItem item)
        {
            if(this.magicItems.Contains(item))
            {
                this.magicItems.Remove(item);
            }
        }
    }
}

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
                foreach (IItem item in this.items)
                {
                    if (item is IAttackItem)
                    {
                        value += (item as IAttackItem).AttackValue;
                    }
                }
                foreach (IMagicalItem item in this.magicItems)
                {
                    if (item is IMagicalAttackItem)
                    {
                        value += (item as IMagicalAttackItem).AttackValue;
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
                foreach (IItem item in this.items)
                {
                    if (item is IDefenseItem)
                    {
                        value += (item as IDefenseItem).DefenseValue;
                    }
                }
                foreach (IMagicalItem item in this.magicItems)
                {
                    if (item is IMagicalDefenseItem)
                    {
                        value += (item as IMagicalDefenseItem).DefenseValue;
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

using System.Collections.Generic;
namespace RoleplayGame
{
    public abstract class Character 
    {
        public int VictoryPoints { get; set; } = 0;
        protected int health = 100;

        protected List<IItem> items = new List<IItem>();
        public string Name { get; set; }
        
        public virtual int AttackValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is AttackItem)
                    {
                        value += (item as AttackItem).Attack;
                    }
                }
                return value;
            }
        }

        public virtual int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (IItem item in this.items)
                {
                    if (item is DefenseItem)
                    {
                        value += (item as DefenseItem).Defense;
                    }
                }
                return value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public void ReceiveAttack(int power)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
        }

        public void Cure()
        {
            this.Health = 100;
        }

        public void AddItem(IItem item)
        {
            this.items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            this.items.Remove(item);
        }
    }
}
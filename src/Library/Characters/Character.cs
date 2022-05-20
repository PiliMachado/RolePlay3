using System.Collections.Generic;

namespace RoleplayGame
{
    public abstract class Character 
    {
        public int VictoryPoints {get; set;}
        protected int health = 100;

        private List<IItem> items = new List<IItem>();
        public List<IItem> Items {
            get{
                return new List<IItem>(this.items);
            }
            protected set{
                this.items = value;
            }
        }
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
            if(!this.Items.Contains(item)) this.items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            if(this.Items.Contains(item)) this.items.Remove(item);
        }
    }
}
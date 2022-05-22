namespace RoleplayGame
{
    public class MagicalDefenseItem: IMagicalItem
    {
        protected int defense;
        public virtual int Defense
        {
            get
            {
                return this.defense;
            }
            set
            {
                if(value >=0)
                {
                    this.defense = value;
                }
                else
                {
                    this.defense = 0;
                } 
            }
        }
    }
}
namespace RoleplayGame
{
    public class MagicalAttackItem: IMagicalItem
    {
        protected int attack;
        public virtual int Attack
        {
            get
            {
                return this.attack;
            }
            set
            {
                if(value >=0)
                {
                    this.attack = value;
                }
                else
                {
                    this.attack = 0;
                } 
            }
        }
    }
}
namespace RoleplayGame
{
    public class MagicalAttackItem: IMagicalItem
    {
        protected int Attack;
        public virtual int AttackValue
        {
            get
            {
                return this.Attack;
            }
            set
            {
                if(value >=0)
                {
                    this.Attack = value;
                }
                else
                {
                    this.Attack = 0;
                } 
            }
        }
    }
}
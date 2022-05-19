namespace RoleplayGame
{
    public class MagicalAttackDefenseItem
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

        protected int Defense;
        public virtual int DefenseValue
        {
            get
            {
                return this.Defense;
            }
            set
            {
                if(value >=0)
                {
                    this.Defense = value;
                }
                else
                {
                    this.Defense = 0;
                } 
            }
        }
    }
}
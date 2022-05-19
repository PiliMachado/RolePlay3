namespace RoleplayGame
{
    public class MagicalDefenseItem: IMagicalItem
    {
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
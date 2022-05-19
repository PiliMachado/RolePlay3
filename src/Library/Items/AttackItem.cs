namespace RoleplayGame
{
public class AttackItem : IItem
    {

        protected int Attack;
        public int AttackValue
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

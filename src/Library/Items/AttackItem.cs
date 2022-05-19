namespace RoleplayGame
{
public class AttackItem : IItem
    {

        protected int attack;
        public int Attack
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

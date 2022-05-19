namespace RoleplayGame
{
public class DefenseItem : IItem
    {

        protected int defense;
        public int Defense
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
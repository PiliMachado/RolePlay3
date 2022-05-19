namespace RoleplayGame
{
public class DefenseItem : IItem
    {

        protected int Defense;
        public int DefenseValue
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
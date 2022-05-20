namespace RoleplayGame
{
    public class Spell
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
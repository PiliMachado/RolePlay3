using System.Collections.Generic;
namespace RoleplayGame
{
    public class Archer: Character, IHero
    {
        public Archer(string name)
        {
            this.Name = name;
        }
    }
}
using System.Collections.Generic;
namespace RoleplayGame
{
    public class Knight: Character, IHero
    {
        public Knight(string name)
        {
            this.Name = name;
        }
    }
}
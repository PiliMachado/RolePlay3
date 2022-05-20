using System.Collections.Generic;
namespace RoleplayGame
{
    public class Dwarf: Character, IHero
    {
        public Dwarf(string name)
        {
            this.Name = name;
        }
    }
}
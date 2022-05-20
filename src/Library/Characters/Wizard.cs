using System.Collections.Generic;
namespace RoleplayGame
{
    public class Wizard: MagicCharacter, IHero
    {
        public Wizard(string name)
        {
            this.Name = name;
        }
    }
}
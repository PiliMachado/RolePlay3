using System.Collections.Generic;
namespace RoleplayGame
{
    public class Undead: MagicCharacter, IEnemy
    {
        public Undead(string name)
        {
            this.Name = name;
        }
    }
}
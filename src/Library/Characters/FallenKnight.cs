using System.Collections.Generic;
namespace RoleplayGame
{
    public class FallenKnight: Character, IEnemy
    {
        public FallenKnight(string name)
        {
            this.Name = name;
        }
    }
}
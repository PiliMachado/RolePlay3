using System.Collections.Generic;
namespace RoleplayGame
{
    public class ShadowGnome: Character, IEnemy
    {
        public ShadowGnome(string name)
        {
            this.Name = name;
        }
    }
}
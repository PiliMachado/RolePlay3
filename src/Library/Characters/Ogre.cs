using System.Collections.Generic;
namespace RoleplayGame
{
    public class Ogre: Character, IEnemy
    {
        public Ogre(string name)
        {
            this.Name = name;
        }
    }
}
using System.Collections.Generic;
namespace RoleplayGame
{
    public class DarkElf: Character, IEnemy
    {
        public DarkElf(string name)
        {
            this.Name = name;
        }
    }
}
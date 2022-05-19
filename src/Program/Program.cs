using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            SpellsBook book = new SpellsBook();
            book.AddSpell(new SpellOne());
            book.AddSpell(new SpellOne());

            Wizard gandalf = new Wizard("Gandalf");
            gandalf.AddItem(book);

            Dwarf gimli = new Dwarf("Gimli");

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

            gimli.ReceiveAttack(gandalf.AttackValue);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Someone cured Gimli. Gimli now has ❤️ {gimli.Health}");
            */
            Archer archer = new Archer("archer");
            DarkElf darkelf = new DarkElf("darkelf");
            Dwarf dwarf = new Dwarf("dwarf");
            Knight knight = new Knight("knight");
            Ogre ogre = new Ogre("ogre");
            ShadowGnome shadowgnome = new ShadowGnome("shadowgnome");
            Undead undead = new Undead("undead");
            Wizard wizard = new Wizard("wizard");
            
        }
    }
}

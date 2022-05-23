using NUnit.Framework;
using RoleplayGame;
using System.Collections.Generic;

namespace Test.Library
{
    public class SpellsBookTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SingleSpellGetAttackValueTest() // Testeamos que el ataque del spellbook se calcule correctamente con un unico spell.
        {
            SpellsBook spellsBook = new SpellsBook();
            Spell SpellOne = new SpellOne(10, 0);
            List<Spell> spells = new List<Spell>();
            spells.Add(SpellOne);
            spellsBook.Spells = spells;
            int actual = spellsBook.Attack;
            Assert.AreEqual(SpellOne.AttackValue, actual);
        }

        [Test]
        public void MultipleSpellsGetAttackValueTest()  // Testeamos que el ataque del spellbook se calcule correctamente con varios spells.
        {
            SpellsBook spellsBook = new SpellsBook();
            Spell SpellOne = new SpellOne(15, 0);
            Spell SpellOne2 = new SpellOne(25, 0);
            Spell SpellOne3 = new SpellOne(60, 0);
            List<Spell> spells = new List<Spell>();
            spells.Add(SpellOne);
            spells.Add(SpellOne2);
            spells.Add(SpellOne3);
            spellsBook.Spells = spells;
            int actual = spellsBook.Attack;
            Assert.AreEqual(SpellOne.AttackValue + SpellOne2.AttackValue + SpellOne3.AttackValue, actual);
        }

        [Test]
        public void SingleSpellGetDefenseTest() // Testeamos que la defensa del spellbook se calcule correctamente con un unico spell.
        {
            SpellsBook spellsBook = new SpellsBook();
            Spell SpellOne = new SpellOne(0, 10);
            List<Spell> spells = new List<Spell>();
            spells.Add(SpellOne);
            spellsBook.Spells = spells;
            int actual = spellsBook.Defense;
            Assert.AreEqual(SpellOne.DefenseValue, actual);
        }

        [Test]
        public void MultipleSpellsGetDefenseTest() // Testeamos que la defensa del spellbook se calcule correctamente con varios spells.
        {
            SpellsBook spellsBook = new SpellsBook();
            Spell SpellOne = new SpellOne(0, 25);
            Spell SpellOne2 = new SpellOne(0, 35);
            Spell SpellOne3 = new SpellOne(0, 40);
            List<Spell> spells = new List<Spell>();
            spells.Add(SpellOne);
            spells.Add(SpellOne2);
            spells.Add(SpellOne3);
            spellsBook.Spells = spells;
            int actual = spellsBook.Defense;
            Assert.AreEqual(SpellOne.DefenseValue + SpellOne2.DefenseValue + SpellOne3.DefenseValue, actual);
        }
    }
}
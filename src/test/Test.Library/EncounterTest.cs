using NUnit.Framework;
using RoleplayGame;
using System.Collections.Generic;

namespace Test.Library
{
    public class EncounterTest
    {
        
        [SetUp]
        public void SetUp()
        {
            
        }

        /// <summary>
        /// Probamos que si hay una cantidad invalida de characters (es decir no hay almenos un enemigo
        /// y un heroe), que el encounter no ocurriera.
        /// </summary>
        [Test]
        public void InvalidAmountOfCharactersTest()
        {
            Archer archer = new Archer("archer");
            Dwarf dwarf = new Dwarf("dwarf");
            List<Character> characters = new List<Character>();
            characters.Add(archer);
            characters.Add(dwarf);
            Encounter encounter = new Encounter(characters);
            encounter.DoEncounter();
            Assert.AreEqual(encounter.done, false);
        }

        /// <summary>
        /// Probamos que si hay multiples enemigos y un unico heroe, los enemigos le peguen cada uno
        /// al mismo heroe, esto se puede verificar dandole un ataque muy elevado al heroe y el daño justo a los enemigos, que en caso
        /// de que los villanos no le pegaran todos al heroe, los villanos perderian y el heroe seguiria vivo.
        /// </summary>
        [Test]
        public void MultipleEnemiesOneHeroTest()
        {
            Archer archer = new Archer("archer");
            Ogre ogre = new Ogre("ogre");
            ShadowGnome shadowgnome = new ShadowGnome("shadowgnome");
            Undead undead = new Undead("undead");
            List<Character> characters = new List<Character>();
            characters.Add(undead);
            characters.Add(ogre);
            characters.Add(shadowgnome);
            characters.Add(archer);
            MagicalAttackDefenseItem staff = new Staff(33, 300);
            Axe axe = new Axe(33);
            Bow bow = new Bow(34);
            Bow bow2 = new Bow(100000);
            undead.AddItem(staff);
            archer.AddItem(bow2);
            ogre.AddItem(axe);
            shadowgnome.AddItem(bow);
            Encounter encounter = new Encounter(characters);
            encounter.DoEncounter();
            Assert.AreEqual(archer.Health, 0);
        }

        /// <summary>
        /// Probamos que si hay multiples enemigos y multiples heroes, el primer enemigo le pegue al primer heroe
        /// , el segundo enemigo al segundo heroe, y que siga asi. Para esto le dimos un elevado ataque a los heroes suficiente
        /// para en un turno vencer a los enemigos, y a cada enemigo un ataque de 1 para verficar que a cada heroe le pegaron
        /// una vez, quedando asi cada heroe con 99 de vida.
        /// </summary>
        [Test]
        public void MultipleEnemiesMultipleHeroesTest()
        {
            Archer archer = new Archer("archer");
            Archer archer2 = new Archer("archer");
            Archer archer3 = new Archer("archer");
            Ogre ogre = new Ogre("ogre");
            ShadowGnome shadowgnome = new ShadowGnome("shadowgnome");
            Undead undead = new Undead("undead");
            List<Character> characters = new List<Character>();
            characters.Add(undead);
            characters.Add(ogre);
            characters.Add(shadowgnome);
            characters.Add(archer);
            characters.Add(archer2);
            characters.Add(archer3);
            MagicalAttackDefenseItem staff = new Staff(1, 0);
            Axe axe = new Axe(1);
            Bow bow = new Bow(1);
            Bow bow2 = new Bow(100000);
            undead.AddItem(staff);
            archer.AddItem(bow2);
            archer2.AddItem(bow2);
            archer3.AddItem(bow2);
            ogre.AddItem(axe);
            shadowgnome.AddItem(bow);
            Encounter encounter = new Encounter(characters);
            encounter.DoEncounter();
            Assert.AreEqual(archer.Health, 99);
            Assert.AreEqual(archer2.Health, 99);
            Assert.AreEqual(archer3.Health, 99);
        }

        /// <summary>
        /// Probamos que al haber menos heroes que enemigos 2 enemigos consecutivos le pegaran
        /// al mismo heroe. Esto lo se puede verificar de la misma forma que verificamos el test anterior.
        /// Ademas los outputs demuestran que ello fue lo sucedido.
        /// </summary>
        [Test]
        public void LessHeroesThanEnemiesTest()
        {
            Archer archer = new Archer("archer");
            Archer archer2 = new Archer("archer2");
            Archer archer3 = new Archer("archer3");
            Ogre ogre = new Ogre("ogre");
            Ogre ogre2 = new Ogre("ogre");
            ShadowGnome shadowgnome = new ShadowGnome("shadowgnome");
            ShadowGnome shadowgnome2 = new ShadowGnome("shadowgnome");
            Undead undead = new Undead("undead");
            Undead undead2 = new Undead("undead");
            List<Character> characters = new List<Character>();
            characters.Add(undead);
            characters.Add(undead2);
            characters.Add(ogre);
            characters.Add(ogre2);
            characters.Add(shadowgnome);
            characters.Add(shadowgnome2);
            characters.Add(archer);
            characters.Add(archer2);
            characters.Add(archer3);
            MagicalAttackDefenseItem staff = new Staff(1, 0);
            Axe axe = new Axe(1);
            Bow bow = new Bow(1);
            Bow bow2 = new Bow(100000);
            undead.AddItem(staff);
            undead2.AddItem(staff);
            archer.AddItem(bow2);
            archer2.AddItem(bow2);
            archer3.AddItem(bow2);
            ogre.AddItem(axe);
            ogre2.AddItem(axe);
            shadowgnome.AddItem(bow);
            shadowgnome2.AddItem(bow);
            Encounter encounter = new Encounter(characters);
            encounter.DoEncounter();
            Assert.AreEqual(archer.Health, 98);
            Assert.AreEqual(archer2.Health, 98);
            Assert.AreEqual(archer3.Health, 98);
        }

        /// <summary>
        /// Probamos que si hay multiples enemigos y multiples heroes, cada heroe le pega a cada enemigo.
        /// Como tenemos 3 heroes que pierden despues de un turno, y el ataque de cada uno es 3, deberia
        /// cada enemigo perder 3 de vida.
        /// </summary>
        [Test]
        public void HeroesAttackPatternTest()
        {
            Archer archer = new Archer("archer");
            Archer archer2 = new Archer("archer2");
            Archer archer3 = new Archer("archer3");
            Ogre ogre = new Ogre("ogre");
            ShadowGnome shadowgnome = new ShadowGnome("shadowgnome");
            Undead undead = new Undead("undead");
            List<Character> characters = new List<Character>();
            characters.Add(undead);
            characters.Add(ogre);
            characters.Add(shadowgnome);
            characters.Add(archer);
            characters.Add(archer2);
            characters.Add(archer3);
            MagicalAttackDefenseItem staff = new Staff(99, 0);
            Axe axe = new Axe(99);
            Bow bow = new Bow(99);
            Bow bow2 = new Bow(1);
            undead.AddItem(staff);
            archer.AddItem(bow2);
            archer2.AddItem(bow2);
            archer3.AddItem(bow2);
            ogre.AddItem(axe);
            shadowgnome.AddItem(bow);
            Encounter encounter = new Encounter(characters);
            encounter.DoEncounter();
            Assert.AreEqual(ogre.Health, 97);
            Assert.AreEqual(undead.Health, 97);
            Assert.AreEqual(shadowgnome.Health, 97);
        }

        /// <summary>
        /// Probamos que un heroe obtenga los VictoryPoints al derrotar a los enemigos.
        /// </summary>
        [Test]
        public void CorrectVPTest()
        {
            Archer archer = new Archer("archer");
            Ogre ogre = new Ogre("ogre");
            ogre.VictoryPoints = 1;
            ShadowGnome shadowgnome = new ShadowGnome("shadowgnome");
            shadowgnome.VictoryPoints = 1;
            Undead undead = new Undead("undead");
            undead.VictoryPoints = 1;
            List<Character> characters = new List<Character>();
            characters.Add(undead);
            characters.Add(ogre);
            characters.Add(shadowgnome);
            characters.Add(archer);
            MagicalAttackDefenseItem staff = new Staff(1, 0);
            Axe axe = new Axe(1);
            Bow bow = new Bow(1);
            Bow bow2 = new Bow(100000);
            undead.AddItem(staff);
            archer.AddItem(bow2);
            ogre.AddItem(axe);
            shadowgnome.AddItem(bow);
            Encounter encounter = new Encounter(characters);
            encounter.DoEncounter();
            Assert.AreEqual(archer.VictoryPoints, 3);
        }
    }
}
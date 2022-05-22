using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;
using System.IO;

namespace Test.Library
{

    public class EncounterTest
    {
        [Test]
        public void crearEncounterSinPersonajesFallaTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                System.Console.SetOut(sw);

                Encounter encounter = new Encounter(new List<Character>());
                encounter.DoEncounter();

                string expected = "Missing characters to start encounter.";

                Assert.That(sw.ToString().Replace("\r", "").Replace("\n", ""),
                 Is.EqualTo(expected.Replace("\r", "").Replace("\n", "")));
            }
        }

        [Test]
        public void crearEncounterGananHeroesTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                System.Console.SetOut(sw);

                List<Character> personajes = new List<Character>();
                Character archer = new Archer("juan pablo");
                archer.AddItem(new Bow(547));
                Character dragon = new Dragon("carlitos");
                personajes.AddRange(new Character[]{archer, dragon});

                Encounter encounter = new Encounter(personajes);
                encounter.DoEncounter();

                string expected = "The heroes won!";

                Assert.That(sw.ToString().Replace("\r", "").Replace("\n", ""),
                    Is.EqualTo(expected.Replace("\r", "").Replace("\n", "")));
                Assert.AreEqual(0, encounter.Villians.Count);
                Assert.AreEqual(1, encounter.Heroes.Count);
            }
        }

        [Test]
        public void crearEncounterGananVillanosTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                System.Console.SetOut(sw);

                List<Character> personajes = new List<Character>();
                Character archer = new Archer("juan pablo");
                Character dragon = new Dragon("carlitos");
                dragon.AddItem(new Axe(8_000));
                personajes.AddRange(new Character[]{archer, dragon});

                Encounter encounter = new Encounter(personajes);
                encounter.DoEncounter();

                string expected = "The villains won!";

                Assert.That(sw.ToString().Replace("\r", "").Replace("\n", "")
                , Is.EqualTo(expected.Replace("\r", "").Replace("\n", "")));
                Assert.AreEqual(1, encounter.Villians.Count);
                Assert.AreEqual(0, encounter.Heroes.Count);
            }
        }
    }
}
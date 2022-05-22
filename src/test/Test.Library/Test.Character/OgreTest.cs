using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class OgreTest
    {
        /// <summary>
        /// Verificamos que el daño se aplique correctamente.
        /// </summary>
        [Test]
        public void OgreAttackTest()
        {
            Ogre Ogre = new Ogre("Jose pedro");
            Ogre Ogre2 = new Ogre("Pablito");

            foreach(AttackItem item in new AttackItem[]{new Axe(13), new Axe(10), new Axe(20)})
            {
                Ogre.AddItem(item);
            }
            Ogre.ReceiveAttack(Ogre2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(Ogre2.AttackValue > Ogre.DefenseValue ? 
                    Ogre2.AttackValue - Ogre.DefenseValue :
                    0)
                 ),
             Ogre.Health);
        }


        /// <summary>
        /// Verificamos que la defensa tenga efecto al momento de recibir un ataque.
        /// </summary>
        [Test]
        public void OgreDefenseTest()
        {
            Ogre Ogre = new Ogre("Jose pedro");
            Ogre Ogre2 = new Ogre("Pablito");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                Ogre.AddItem(item);
            }
            Ogre.ReceiveAttack(Ogre2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(Ogre2.AttackValue > Ogre.DefenseValue ? 
                    Ogre2.AttackValue - Ogre.DefenseValue :
                    0)
                 ),
             Ogre.Health);
        }

        [Test]
        public void OgreAttackValueTest()
        {
            Ogre Ogre = new Ogre("Jose pedro");
            foreach(AttackItem item in new AttackItem[]{new Axe(13), new Axe(10), new Axe(20)})
            {
                Ogre.AddItem(item);
            }
            int expected = 13+10+20;

            Assert.AreEqual(expected, Ogre.AttackValue);
        }

        [Test]
        public void OgreDefenseValueTest()
        {
            Ogre Ogre = new Ogre("Jose pedro");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                Ogre.AddItem(item);
            }
            int expected = 12+1+4;

            Assert.AreEqual(expected, Ogre.DefenseValue);
        }

        [Test]
        public void OgreEquipItemTest()
        {
            Ogre Ogre = new Ogre("Jose pedro");

            Ogre.AddItem(new Helmet(13));
            Ogre.AddItem(new Axe(13));

            Assert.AreEqual(1, Ogre.Items.FindAll(i => i is AttackItem).Count);
            Assert.AreEqual(1, Ogre.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void OgreCannotEquipAlreadyEquippedItemTest()
        {
            Ogre Ogre = new Ogre("Jose pedro");

            DefenseItem helmet = new Helmet(494_206_903);
            Ogre.AddItem(helmet);
            Ogre.AddItem(helmet);
            
            Assert.AreEqual(1, Ogre.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void OgreDequipItemTest()
        {
            Ogre Ogre = new Ogre("Jose pedro");


            DefenseItem helmet = new Helmet(123);
            Ogre.AddItem(helmet);

            Assert.AreEqual(1, Ogre.Items.FindAll(i => i is DefenseItem).Count);

            Ogre.RemoveItem(helmet);
            
            Assert.AreEqual(0, Ogre.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void OgreCannotDequipNotEquippedItemTest()
        {
            Ogre Ogre = new Ogre("Jose pedro");

            DefenseItem helmet = new Helmet(123);

            Ogre.AddItem(new Helmet(123));
            Ogre.RemoveItem(helmet);

            Assert.AreEqual(1, Ogre.Items.FindAll(i => i is DefenseItem).Count);
        }
        
    }
}
using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class DarkElfTest
    {
        /// <summary>
        /// Verificamos que el daño se aplique correctamente.
        /// </summary>
        [Test]
        public void DarkElfAttackTest()
        {
            DarkElf DarkElf = new DarkElf("Jose pedro");
            DarkElf DarkElf2 = new DarkElf("Pablito");

            foreach(AttackItem item in new AttackItem[]{new Bow(13), new Bow(10), new Bow(20)})
            {
                DarkElf.AddItem(item);
            }
            DarkElf.ReceiveAttack(DarkElf2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(DarkElf2.AttackValue > DarkElf.DefenseValue ? 
                    DarkElf2.AttackValue - DarkElf.DefenseValue :
                    0)
                 ),
             DarkElf.Health);
        }


        /// <summary>
        /// Verificamos que la defensa tenga efecto al momento de recibir un ataque.
        /// </summary>
        [Test]
        public void DarkElfDefenseTest()
        {
            DarkElf DarkElf = new DarkElf("Jose pedro");
            DarkElf DarkElf2 = new DarkElf("Pablito");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                DarkElf.AddItem(item);
            }
            DarkElf.ReceiveAttack(DarkElf2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(DarkElf2.AttackValue > DarkElf.DefenseValue ? 
                    DarkElf2.AttackValue - DarkElf.DefenseValue :
                    0)
                 ),
             DarkElf.Health);
        }

        [Test]
        public void DarkElfAttackValueTest()
        {
            DarkElf DarkElf = new DarkElf("Jose pedro");
            foreach(AttackItem item in new AttackItem[]{new Bow(13), new Bow(10), new Bow(20)})
            {
                DarkElf.AddItem(item);
            }
            int expected = 13+10+20;

            Assert.AreEqual(expected, DarkElf.AttackValue);
        }

        [Test]
        public void DarkElfDefenseValueTest()
        {
            DarkElf DarkElf = new DarkElf("Jose pedro");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                DarkElf.AddItem(item);
            }
            int expected = 12+1+4;

            Assert.AreEqual(expected, DarkElf.DefenseValue);
        }

        [Test]
        public void DarkElfEquipItemTest()
        {
            DarkElf DarkElf = new DarkElf("Jose pedro");

            DarkElf.AddItem(new Helmet(13));
            DarkElf.AddItem(new Bow(13));

            Assert.AreEqual(1, DarkElf.Items.FindAll(i => i is AttackItem).Count);
            Assert.AreEqual(1, DarkElf.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void DarkElfCannotEquipAlreadyEquippedItemTest()
        {
            DarkElf DarkElf = new DarkElf("Jose pedro");

            DefenseItem helmet = new Helmet(494_206_903);
            DarkElf.AddItem(helmet);
            DarkElf.AddItem(helmet);
            
            Assert.AreEqual(1, DarkElf.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void DarkElfDequipItemTest()
        {
            DarkElf DarkElf = new DarkElf("Jose pedro");


            DefenseItem helmet = new Helmet(123);
            DarkElf.AddItem(helmet);

            Assert.AreEqual(1, DarkElf.Items.FindAll(i => i is DefenseItem).Count);

            DarkElf.RemoveItem(helmet);
            
            Assert.AreEqual(0, DarkElf.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void DarkElfCannotDequipNotEquippedItemTest()
        {
            DarkElf DarkElf = new DarkElf("Jose pedro");

            DefenseItem helmet = new Helmet(123);

            DarkElf.AddItem(new Helmet(123));
            DarkElf.RemoveItem(helmet);

            Assert.AreEqual(1, DarkElf.Items.FindAll(i => i is DefenseItem).Count);
        }
        
    }
}
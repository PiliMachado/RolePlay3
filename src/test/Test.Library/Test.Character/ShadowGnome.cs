using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class ShadowGnomeTest
    {
        /// <summary>
        /// Verificamos que el daño se aplique correctamente.
        /// </summary>
        [Test]
        public void ShadowGnomeAttackTest()
        {
            ShadowGnome ShadowGnome = new ShadowGnome("Jose pedro");
            ShadowGnome ShadowGnome2 = new ShadowGnome("Pablito");

            foreach(AttackItem item in new AttackItem[]{new Axe(13), new Axe(10), new Axe(20)})
            {
                ShadowGnome.AddItem(item);
            }
            ShadowGnome.ReceiveAttack(ShadowGnome2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(ShadowGnome2.AttackValue > ShadowGnome.DefenseValue ? 
                    ShadowGnome2.AttackValue - ShadowGnome.DefenseValue :
                    0)
                 ),
             ShadowGnome.Health);
        }


        /// <summary>
        /// Verificamos que la defensa tenga efecto al momento de recibir un ataque.
        /// </summary>
        [Test]
        public void ShadowGnomeDefenseTest()
        {
            ShadowGnome ShadowGnome = new ShadowGnome("Jose pedro");
            ShadowGnome ShadowGnome2 = new ShadowGnome("Pablito");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                ShadowGnome.AddItem(item);
            }
            ShadowGnome.ReceiveAttack(ShadowGnome2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(ShadowGnome2.AttackValue > ShadowGnome.DefenseValue ? 
                    ShadowGnome2.AttackValue - ShadowGnome.DefenseValue :
                    0)
                 ),
             ShadowGnome.Health);
        }

        [Test]
        public void ShadowGnomeAttackValueTest()
        {
            ShadowGnome ShadowGnome = new ShadowGnome("Jose pedro");
            foreach(AttackItem item in new AttackItem[]{new Axe(13), new Axe(10), new Axe(20)})
            {
                ShadowGnome.AddItem(item);
            }
            int expected = 13+10+20;

            Assert.AreEqual(expected, ShadowGnome.AttackValue);
        }

        [Test]
        public void ShadowGnomeDefenseValueTest()
        {
            ShadowGnome ShadowGnome = new ShadowGnome("Jose pedro");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                ShadowGnome.AddItem(item);
            }
            int expected = 12+1+4;

            Assert.AreEqual(expected, ShadowGnome.DefenseValue);
        }

        [Test]
        public void ShadowGnomeEquipItemTest()
        {
            ShadowGnome ShadowGnome = new ShadowGnome("Jose pedro");

            ShadowGnome.AddItem(new Helmet(13));
            ShadowGnome.AddItem(new Axe(13));

            Assert.AreEqual(1, ShadowGnome.Items.FindAll(i => i is AttackItem).Count);
            Assert.AreEqual(1, ShadowGnome.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void ShadowGnomeCannotEquipAlreadyEquippedItemTest()
        {
            ShadowGnome ShadowGnome = new ShadowGnome("Jose pedro");

            DefenseItem helmet = new Helmet(494_206_903);
            ShadowGnome.AddItem(helmet);
            ShadowGnome.AddItem(helmet);
            
            Assert.AreEqual(1, ShadowGnome.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void ShadowGnomeDequipItemTest()
        {
            ShadowGnome ShadowGnome = new ShadowGnome("Jose pedro");


            DefenseItem helmet = new Helmet(123);
            ShadowGnome.AddItem(helmet);

            Assert.AreEqual(1, ShadowGnome.Items.FindAll(i => i is DefenseItem).Count);

            ShadowGnome.RemoveItem(helmet);
            
            Assert.AreEqual(0, ShadowGnome.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void ShadowGnomeCannotDequipNotEquippedItemTest()
        {
            ShadowGnome ShadowGnome = new ShadowGnome("Jose pedro");

            DefenseItem helmet = new Helmet(123);

            ShadowGnome.AddItem(new Helmet(123));
            ShadowGnome.RemoveItem(helmet);

            Assert.AreEqual(1, ShadowGnome.Items.FindAll(i => i is DefenseItem).Count);
        }
        
    }
}
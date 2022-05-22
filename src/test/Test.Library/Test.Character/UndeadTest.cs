using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class UndeadTest
    {
        /// <summary>
        /// Verificamos que el daño se aplique correctamente.
        /// </summary>
        [Test]
        public void UndeadAttackWithOnlyAttackItemsTest()
        {
            Undead Undead = new Undead("Jose pedro");
            Undead Undead2 = new Undead("Pablito");

            foreach(AttackItem item in new AttackItem[]{new Bow(13), new Bow(10), new Bow(20)})
            {
                Undead.AddItem(item);
            }
            Undead.ReceiveAttack(Undead2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(Undead2.AttackValue > Undead.DefenseValue ? 
                    Undead2.AttackValue - Undead.DefenseValue :
                    0)
                 ),
             Undead.Health);
        }

        /// <summary>
        /// Verificamos que el daño se aplique correctamente.
        /// </summary>
        [Test]
        public void UndeadAttackWithAttackAndMagicalItemsTest()
        {
            Undead Undead = new Undead("Jose pedro");
            Undead Undead2 = new Undead("Pablito");

            foreach(AttackItem item in new AttackItem[]{new Bow(13), new Bow(10), new Bow(20)})
            {
                Undead.AddItem(item);
            }
            foreach(MagicalAttackDefenseItem item in new MagicalAttackDefenseItem[]{new Staff(13, 0), new Staff(10, 0), new Staff(20, 0)})
            {
                Undead.AddItem(item);
            }
            Undead.ReceiveAttack(Undead2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(Undead2.AttackValue > Undead.DefenseValue ? 
                    Undead2.AttackValue - Undead.DefenseValue :
                    0)
                 ),
             Undead.Health);
        }


        /// <summary>
        /// Verificamos que la defensa tenga efecto al momento de recibir un ataque.
        /// </summary>
        [Test]
        public void UndeadDefenseWithOnlyDefenseItemsTest()
        {
            Undead Undead = new Undead("Jose pedro");
            Undead Undead2 = new Undead("Pablito");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                Undead.AddItem(item);
            }
            Undead.ReceiveAttack(Undead2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(Undead2.AttackValue > Undead.DefenseValue ? 
                    Undead2.AttackValue - Undead.DefenseValue :
                    0)
                 ),
             Undead.Health);
        }

        /// <summary>
        /// Verificamos que la defensa tenga efecto al momento de recibir un ataque.
        /// </summary>
        [Test]
        public void UndeadDefenseWithDefenseAndMagicalItemsTest()
        {
            Undead Undead = new Undead("Jose pedro");
            Undead Undead2 = new Undead("Pablito");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                Undead.AddItem(item);
            }
            foreach(MagicalAttackDefenseItem item in new MagicalAttackDefenseItem[]{new Staff(0, 13), new Staff(0, 4), new Staff(0, 3)})
            {
                Undead.AddItem(item);
            }
            Undead.ReceiveAttack(Undead2.AttackValue);
            Assert.AreEqual(
                Math.Max(0,
                    100-(Undead2.AttackValue > Undead.DefenseValue ? 
                    Undead2.AttackValue - Undead.DefenseValue :
                    0)
                 ),
             Undead.Health);
        }

        [Test]
        public void UndeadAttackValueTest()
        {
            Undead Undead = new Undead("Jose pedro");
            foreach(AttackItem item in new AttackItem[]{new Bow(13), new Bow(10), new Bow(20)})
            {
                Undead.AddItem(item);
            }
            int expected = 13+10+20;

            Assert.AreEqual(expected, Undead.AttackValue);
        }

        [Test]
        public void UndeadDefenseValueTest()
        {
            Undead Undead = new Undead("Jose pedro");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                Undead.AddItem(item);
            }
            int expected = 12+1+4;

            Assert.AreEqual(expected, Undead.DefenseValue);
        }

        [Test]
        public void UndeadEquipItemTest()
        {
            Undead Undead = new Undead("Jose pedro");

            Undead.AddItem(new Helmet(13));
            Undead.AddItem(new Bow(13));

            Assert.AreEqual(1, Undead.Items.FindAll(i => i is AttackItem).Count);
            Assert.AreEqual(1, Undead.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void UndeadCannotEquipAlreadyEquippedItemTest()
        {
            Undead Undead = new Undead("Jose pedro");

            DefenseItem helmet = new Helmet(494_206_903);
            Undead.AddItem(helmet);
            Undead.AddItem(helmet);
            
            Assert.AreEqual(1, Undead.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void UndeadDequipItemTest()
        {
            Undead Undead = new Undead("Jose pedro");


            DefenseItem helmet = new Helmet(123);
            Undead.AddItem(helmet);

            Assert.AreEqual(1, Undead.Items.FindAll(i => i is DefenseItem).Count);

            Undead.RemoveItem(helmet);
            
            Assert.AreEqual(0, Undead.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void UndeadCannotDequipNotEquippedItemTest()
        {
            Undead Undead = new Undead("Jose pedro");

            DefenseItem helmet = new Helmet(123);

            Undead.AddItem(new Helmet(123));
            Undead.RemoveItem(helmet);

            Assert.AreEqual(1, Undead.Items.FindAll(i => i is DefenseItem).Count);
        }
        
    }
}
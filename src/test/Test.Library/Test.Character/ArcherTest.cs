using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class ArcherTest
    {
        /// <summary>
        /// Verificamos que el daño se aplique correctamente.
        /// </summary>
        [Test]
        public void ArcherAttackTest()
        {
            Archer archer = new Archer("Jose pedro");
            Archer archer2 = new Archer("Pablito");

            foreach(AttackItem item in new AttackItem[]{new Bow(13), new Bow(10), new Bow(20)})
            {
                archer.AddItem(item);
            }
            archer.ReceiveAttack(archer2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(archer2.AttackValue > archer.DefenseValue ? 
                    archer2.AttackValue - archer.DefenseValue :
                    0)
                 ),
             archer.Health);
        }


        /// <summary>
        /// Verificamos que la defensa tenga efecto al momento de recibir un ataque.
        /// </summary>
        [Test]
        public void ArcherDefenseTest()
        {
            Archer archer = new Archer("Jose pedro");
            Archer archer2 = new Archer("Pablito");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                archer.AddItem(item);
            }
            archer.ReceiveAttack(archer2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(archer2.AttackValue > archer.DefenseValue ? 
                    archer2.AttackValue - archer.DefenseValue :
                    0)
                 ),
             archer.Health);
        }

        [Test]
        public void ArcherAttackValueTest()
        {
            Archer archer = new Archer("Jose pedro");
            foreach(AttackItem item in new AttackItem[]{new Bow(13), new Bow(10), new Bow(20)})
            {
                archer.AddItem(item);
            }
            int expected = 13+10+20;

            Assert.AreEqual(expected, archer.AttackValue);
        }

        [Test]
        public void ArcherDefenseValueTest()
        {
            Archer archer = new Archer("Jose pedro");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                archer.AddItem(item);
            }
            int expected = 12+1+4;

            Assert.AreEqual(expected, archer.DefenseValue);
        }

        [Test]
        public void ArcherEquipItemTest()
        {
            Archer archer = new Archer("Jose pedro");

            archer.AddItem(new Helmet(13));
            archer.AddItem(new Bow(13));

            Assert.AreEqual(1, archer.Items.FindAll(i => i is AttackItem).Count);
            Assert.AreEqual(1, archer.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void ArcherCannotEquipAlreadyEquippedItemTest()
        {
            Archer archer = new Archer("Jose pedro");

            DefenseItem helmet = new Helmet(494_206_903);
            archer.AddItem(helmet);
            archer.AddItem(helmet);
            
            Assert.AreEqual(1, archer.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void ArcherDequipItemTest()
        {
            Archer archer = new Archer("Jose pedro");


            DefenseItem helmet = new Helmet(123);
            archer.AddItem(helmet);

            Assert.AreEqual(1, archer.Items.FindAll(i => i is DefenseItem).Count);

            archer.RemoveItem(helmet);
            
            Assert.AreEqual(0, archer.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void ArcherCannotDequipNotEquippedItemTest()
        {
            Archer archer = new Archer("Jose pedro");

            DefenseItem helmet = new Helmet(123);

            archer.AddItem(new Helmet(123));
            archer.RemoveItem(helmet);

            Assert.AreEqual(1, archer.Items.FindAll(i => i is DefenseItem).Count);
        }
        
    }
}
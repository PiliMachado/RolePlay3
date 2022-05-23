using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class KnightTest
    {
        /// <summary>
        /// Verificamos que el daño se aplique correctamente.
        /// </summary>
        [Test]
        public void KnightAttackTest()
        {
            Knight Knight = new Knight("Jose pedro");
            Knight Knight2 = new Knight("Pablito");

            foreach(AttackItem item in new AttackItem[]{new Sword(13), new Sword(10), new Sword(20)})
            {
                Knight.AddItem(item);
            }
            Knight.ReceiveAttack(Knight2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(Knight2.AttackValue > Knight.DefenseValue ? 
                    Knight2.AttackValue - Knight.DefenseValue :
                    0)
                 ),
             Knight.Health);
        }


        /// <summary>
        /// Verificamos que la defensa tenga efecto al momento de recibir un ataque.
        /// </summary>
        [Test]
        public void KnightDefenseTest()
        {
            Knight Knight = new Knight("Jose pedro");
            Knight Knight2 = new Knight("Pablito");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                Knight.AddItem(item);
            }
            Knight.ReceiveAttack(Knight2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(Knight2.AttackValue > Knight.DefenseValue ? 
                    Knight2.AttackValue - Knight.DefenseValue :
                    0)
                 ),
             Knight.Health);
        }

        [Test]
        public void KnightAttackValueTest()
        {
            Knight Knight = new Knight("Jose pedro");
            foreach(AttackItem item in new AttackItem[]{new Sword(13), new Sword(10), new Sword(20)})
            {
                Knight.AddItem(item);
            }
            int expected = 13+10+20;

            Assert.AreEqual(expected, Knight.AttackValue);
        }

        [Test]
        public void KnightDefenseValueTest()
        {
            Knight Knight = new Knight("Jose pedro");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                Knight.AddItem(item);
            }
            int expected = 12+1+4;

            Assert.AreEqual(expected, Knight.DefenseValue);
        }

        [Test]
        public void KnightEquipItemTest()
        {
            Knight Knight = new Knight("Jose pedro");

            Knight.AddItem(new Helmet(13));
            Knight.AddItem(new Sword(13));

            Assert.AreEqual(1, Knight.Items.FindAll(i => i is AttackItem).Count);
            Assert.AreEqual(1, Knight.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void KnightCannotEquipAlreadyEquippedItemTest()
        {
            Knight Knight = new Knight("Jose pedro");

            DefenseItem helmet = new Helmet(494_206_903);
            Knight.AddItem(helmet);
            Knight.AddItem(helmet);
            
            Assert.AreEqual(1, Knight.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void KnightDequipItemTest()
        {
            Knight Knight = new Knight("Jose pedro");


            DefenseItem helmet = new Helmet(123);
            Knight.AddItem(helmet);

            Assert.AreEqual(1, Knight.Items.FindAll(i => i is DefenseItem).Count);

            Knight.RemoveItem(helmet);
            
            Assert.AreEqual(0, Knight.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void KnightCannotDequipNotEquippedItemTest()
        {
            Knight Knight = new Knight("Jose pedro");

            DefenseItem helmet = new Helmet(123);

            Knight.AddItem(new Helmet(123));
            Knight.RemoveItem(helmet);

            Assert.AreEqual(1, Knight.Items.FindAll(i => i is DefenseItem).Count);
        }
        
    }
}
using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class FallenKnightTest
    {
        /// <summary>
        /// Verificamos que el daño se aplique correctamente.
        /// </summary>
        [Test]
        public void FallenKnightAttackTest()
        {
            FallenKnight FallenKnight = new FallenKnight("Jose pedro");
            FallenKnight FallenKnight2 = new FallenKnight("Pablito");

            foreach(AttackItem item in new AttackItem[]{new Sword(13), new Sword(10), new Sword(20)})
            {
                FallenKnight.AddItem(item);
            }
            FallenKnight.ReceiveAttack(FallenKnight2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(FallenKnight2.AttackValue > FallenKnight.DefenseValue ? 
                    FallenKnight2.AttackValue - FallenKnight.DefenseValue :
                    0)
                 ),
             FallenKnight.Health);
        }


        /// <summary>
        /// Verificamos que la defensa tenga efecto al momento de recibir un ataque.
        /// </summary>
        [Test]
        public void FallenKnightDefenseTest()
        {
            FallenKnight FallenKnight = new FallenKnight("Jose pedro");
            FallenKnight FallenKnight2 = new FallenKnight("Pablito");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                FallenKnight.AddItem(item);
            }
            FallenKnight.ReceiveAttack(FallenKnight2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(FallenKnight2.AttackValue > FallenKnight.DefenseValue ? 
                    FallenKnight2.AttackValue - FallenKnight.DefenseValue :
                    0)
                 ),
             FallenKnight.Health);
        }

        [Test]
        public void FallenKnightAttackValueTest()
        {
            FallenKnight FallenKnight = new FallenKnight("Jose pedro");
            foreach(AttackItem item in new AttackItem[]{new Sword(13), new Sword(10), new Sword(20)})
            {
                FallenKnight.AddItem(item);
            }
            int expected = 13+10+20;

            Assert.AreEqual(expected, FallenKnight.AttackValue);
        }

        [Test]
        public void FallenKnightDefenseValueTest()
        {
            FallenKnight FallenKnight = new FallenKnight("Jose pedro");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                FallenKnight.AddItem(item);
            }
            int expected = 12+1+4;

            Assert.AreEqual(expected, FallenKnight.DefenseValue);
        }

        [Test]
        public void FallenKnightEquipItemTest()
        {
            FallenKnight FallenKnight = new FallenKnight("Jose pedro");

            FallenKnight.AddItem(new Helmet(13));
            FallenKnight.AddItem(new Sword(13));

            Assert.AreEqual(1, FallenKnight.Items.FindAll(i => i is AttackItem).Count);
            Assert.AreEqual(1, FallenKnight.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void FallenKnightCannotEquipAlreadyEquippedItemTest()
        {
            FallenKnight FallenKnight = new FallenKnight("Jose pedro");

            DefenseItem helmet = new Helmet(494_206_903);
            FallenKnight.AddItem(helmet);
            FallenKnight.AddItem(helmet);
            
            Assert.AreEqual(1, FallenKnight.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void FallenKnightDequipItemTest()
        {
            FallenKnight FallenKnight = new FallenKnight("Jose pedro");


            DefenseItem helmet = new Helmet(123);
            FallenKnight.AddItem(helmet);

            Assert.AreEqual(1, FallenKnight.Items.FindAll(i => i is DefenseItem).Count);

            FallenKnight.RemoveItem(helmet);
            
            Assert.AreEqual(0, FallenKnight.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void FallenKnightCannotDequipNotEquippedItemTest()
        {
            FallenKnight FallenKnight = new FallenKnight("Jose pedro");

            DefenseItem helmet = new Helmet(123);

            FallenKnight.AddItem(new Helmet(123));
            FallenKnight.RemoveItem(helmet);

            Assert.AreEqual(1, FallenKnight.Items.FindAll(i => i is DefenseItem).Count);
        }
        
    }
}
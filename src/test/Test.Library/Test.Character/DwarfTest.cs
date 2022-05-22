using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class DwarfTest
    {
        /// <summary>
        /// Verificamos que el daño se aplique correctamente.
        /// </summary>
        [Test]
        public void DwarfAttackTest()
        {
            Dwarf Dwarf = new Dwarf("Jose pedro");
            Dwarf Dwarf2 = new Dwarf("Pablito");

            foreach(AttackItem item in new AttackItem[]{new Axe(13), new Axe(10), new Axe(20)})
            {
                Dwarf.AddItem(item);
            }
            Dwarf.ReceiveAttack(Dwarf2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(Dwarf2.AttackValue > Dwarf.DefenseValue ? 
                    Dwarf2.AttackValue - Dwarf.DefenseValue :
                    0)
                 ),
             Dwarf.Health);
        }


        /// <summary>
        /// Verificamos que la defensa tenga efecto al momento de recibir un ataque.
        /// </summary>
        [Test]
        public void DwarfDefenseTest()
        {
            Dwarf Dwarf = new Dwarf("Jose pedro");
            Dwarf Dwarf2 = new Dwarf("Pablito");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                Dwarf.AddItem(item);
            }
            Dwarf.ReceiveAttack(Dwarf2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(Dwarf2.AttackValue > Dwarf.DefenseValue ? 
                    Dwarf2.AttackValue - Dwarf.DefenseValue :
                    0)
                 ),
             Dwarf.Health);
        }

        [Test]
        public void DwarfAttackValueTest()
        {
            Dwarf Dwarf = new Dwarf("Jose pedro");
            foreach(AttackItem item in new AttackItem[]{new Bow(13), new Bow(10), new Bow(20)})
            {
                Dwarf.AddItem(item);
            }
            int expected = 13+10+20;

            Assert.AreEqual(expected, Dwarf.AttackValue);
        }

        [Test]
        public void DwarfDefenseValueTest()
        {
            Dwarf Dwarf = new Dwarf("Jose pedro");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                Dwarf.AddItem(item);
            }
            int expected = 12+1+4;

            Assert.AreEqual(expected, Dwarf.DefenseValue);
        }

        [Test]
        public void DwarfEquipItemTest()
        {
            Dwarf Dwarf = new Dwarf("Jose pedro");

            Dwarf.AddItem(new Helmet(13));
            Dwarf.AddItem(new Bow(13));

            Assert.AreEqual(1, Dwarf.Items.FindAll(i => i is AttackItem).Count);
            Assert.AreEqual(1, Dwarf.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void DwarfCannotEquipAlreadyEquippedItemTest()
        {
            Dwarf Dwarf = new Dwarf("Jose pedro");

            DefenseItem helmet = new Helmet(494_206_903);
            Dwarf.AddItem(helmet);
            Dwarf.AddItem(helmet);
            
            Assert.AreEqual(1, Dwarf.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void DwarfDequipItemTest()
        {
            Dwarf Dwarf = new Dwarf("Jose pedro");


            DefenseItem helmet = new Helmet(123);
            Dwarf.AddItem(helmet);

            Assert.AreEqual(1, Dwarf.Items.FindAll(i => i is DefenseItem).Count);

            Dwarf.RemoveItem(helmet);
            
            Assert.AreEqual(0, Dwarf.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void DwarfCannotDequipNotEquippedItemTest()
        {
            Dwarf Dwarf = new Dwarf("Jose pedro");

            DefenseItem helmet = new Helmet(123);

            Dwarf.AddItem(new Helmet(123));
            Dwarf.RemoveItem(helmet);

            Assert.AreEqual(1, Dwarf.Items.FindAll(i => i is DefenseItem).Count);
        }
        
    }
}
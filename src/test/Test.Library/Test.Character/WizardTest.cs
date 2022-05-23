using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class WizardTest
    {
        /// <summary>
        /// Verificamos que el daño se aplique correctamente.
        /// </summary>
        [Test]
        public void WizardAttackWithOnlyAttackItemsTest()
        {
            Wizard Wizard = new Wizard("Jose pedro");
            Wizard Wizard2 = new Wizard("Pablito");

            foreach(AttackItem item in new AttackItem[]{new Sword(13), new Sword(10), new Sword(20)})
            {
                Wizard.AddItem(item);
            }
            Wizard.ReceiveAttack(Wizard2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(Wizard2.AttackValue > Wizard.DefenseValue ? 
                    Wizard2.AttackValue - Wizard.DefenseValue :
                    0)
                 ),
             Wizard.Health);
        }

        /// <summary>
        /// Verificamos que el daño se aplique correctamente.
        /// </summary>
        [Test]
        public void WizardAttackWithAttackAndMagicalItemsTest()
        {
            Wizard Wizard = new Wizard("Jose pedro");
            Wizard Wizard2 = new Wizard("Pablito");

            foreach(AttackItem item in new AttackItem[]{new Sword(13), new Sword(10), new Sword(20)})
            {
                Wizard.AddItem(item);
            }
            foreach(MagicalAttackDefenseItem item in new MagicalAttackDefenseItem[]{new Staff(13, 0), new Staff(10, 0), new Staff(20, 0)})
            {
                Wizard.AddItem(item);
            }
            Wizard.ReceiveAttack(Wizard2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(Wizard2.AttackValue > Wizard.DefenseValue ? 
                    Wizard2.AttackValue - Wizard.DefenseValue :
                    0)
                 ),
             Wizard.Health);
        }


        /// <summary>
        /// Verificamos que la defensa tenga efecto al momento de recibir un ataque.
        /// </summary>
        [Test]
        public void WizardDefenseWithOnlyDefenseItemsTest()
        {
            Wizard Wizard = new Wizard("Jose pedro");
            Wizard Wizard2 = new Wizard("Pablito");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                Wizard.AddItem(item);
            }
            Wizard.ReceiveAttack(Wizard2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(Wizard2.AttackValue > Wizard.DefenseValue ? 
                    Wizard2.AttackValue - Wizard.DefenseValue :
                    0)
                 ),
             Wizard.Health);
        }

        /// <summary>
        /// Verificamos que la defensa tenga efecto al momento de recibir un ataque.
        /// </summary>
        [Test]
        public void WizardDefenseWithDefenseAndMagicalItemsTest()
        {
            Wizard Wizard = new Wizard("Jose pedro");
            Wizard Wizard2 = new Wizard("Pablito");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                Wizard.AddItem(item);
            }
            foreach(MagicalAttackDefenseItem item in new MagicalAttackDefenseItem[]{new Staff(0, 13), new Staff(0, 4), new Staff(0, 3)})
            {
                Wizard.AddItem(item);
            }
            Wizard.ReceiveAttack(Wizard2.AttackValue);
            Assert.AreEqual(
                Math.Max(0,
                    100-(Wizard2.AttackValue > Wizard.DefenseValue ? 
                    Wizard2.AttackValue - Wizard.DefenseValue :
                    0)
                 ),
             Wizard.Health);
        }

        [Test]
        public void WizardAttackValueTest()
        {
            Wizard Wizard = new Wizard("Jose pedro");
            foreach(AttackItem item in new AttackItem[]{new Sword(13), new Sword(10), new Sword(20)})
            {
                Wizard.AddItem(item);
            }
            int expected = 13+10+20;

            Assert.AreEqual(expected, Wizard.AttackValue);
        }

        [Test]
        public void WizardDefenseValueTest()
        {
            Wizard Wizard = new Wizard("Jose pedro");

            foreach(DefenseItem item in new DefenseItem[]{new Helmet(12), new Helmet(1), new Helmet(4)})
            {
                Wizard.AddItem(item);
            }
            int expected = 12+1+4;

            Assert.AreEqual(expected, Wizard.DefenseValue);
        }

        [Test]
        public void WizardEquipItemTest()
        {
            Wizard Wizard = new Wizard("Jose pedro");

            Wizard.AddItem(new Helmet(13));
            Wizard.AddItem(new Sword(13));

            Assert.AreEqual(1, Wizard.Items.FindAll(i => i is AttackItem).Count);
            Assert.AreEqual(1, Wizard.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void WizardCannotEquipAlreadyEquippedItemTest()
        {
            Wizard Wizard = new Wizard("Jose pedro");

            DefenseItem helmet = new Helmet(494_206_903);
            Wizard.AddItem(helmet);
            Wizard.AddItem(helmet);
            
            Assert.AreEqual(1, Wizard.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void WizardDequipItemTest()
        {
            Wizard Wizard = new Wizard("Jose pedro");


            DefenseItem helmet = new Helmet(123);
            Wizard.AddItem(helmet);

            Assert.AreEqual(1, Wizard.Items.FindAll(i => i is DefenseItem).Count);

            Wizard.RemoveItem(helmet);
            
            Assert.AreEqual(0, Wizard.Items.FindAll(i => i is DefenseItem).Count);
        }

        [Test]
        public void WizardCannotDequipNotEquippedItemTest()
        {
            Wizard Wizard = new Wizard("Jose pedro");

            DefenseItem helmet = new Helmet(123);

            Wizard.AddItem(new Helmet(123));
            Wizard.RemoveItem(helmet);

            Assert.AreEqual(1, Wizard.Items.FindAll(i => i is DefenseItem).Count);
        }
        
    }
}
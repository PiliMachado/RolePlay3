using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class ArmorTest
    {
        
        [SetUp]
        public void SetUp()
        {
            
        }
        /*
            Es necesiario probar la asignación de una defensa valida para
            poder confirmar que el setter funciona correctamente
        */
        [Test]
        public void ArmorDefenseValueTest()
        {
            Armor armor = new Armor(50);
            Assert.AreEqual(armor.Defense, 50);
        }
        /*
            Es necesiario probar la asiganción de una defensa invalida para 
            poder confirmar que el setter funciona correctamente 
        */
        [Test]
        public void ArmorDefenseInvalidTest()
        {
            Armor armor = new Armor(-35);
            Assert.AreEqual(armor.Defense, 0);
        }

    }
}
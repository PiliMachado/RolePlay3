using NUnit.Framework;

namespace Test.Library
{
    public class ArmorTest
    {
        private class Armor armor;
        [SetUp]
        public void SetUp()
        {
            this.armor = new Armor(35);
        }
        /*
            Es necesiario probar la asignación de una defensa valida para
            poder confirmar que el setter funciona correctamente
        */
        [Test]
        public void ArmorDefenseValueTest()
        {
            this.armor.DefenseValue = 50;
            Assert.AreEqual(this.armor.DefenseValue, 50);
        }
        /*
            Es necesiario probar la asiganción de una defensa invalida para 
            poder confirmar que el setter funciona correctamente 
        */
        [Test]
        public void ArmorDefenseInvalidTest()
        {
            this.armor.DefenseValue = -35;
            Assert.AreEqual(this.armor.DefenseValue);
        }

    }
}
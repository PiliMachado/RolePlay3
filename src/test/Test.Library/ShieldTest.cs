using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class ShieldTest
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
        public void ShieldDefenseValueTest()
        {
            Shield shield = new Shield(35);
            Assert.AreEqual(shield.Defense, 35);
        }
        /*
            Es necesiario probar la asiganción de una defensa invalida para 
            poder confirmar que el setter funciona correctamente 
        */
        [Test]
        public void ShieldDefenseInvalidTest()
        {
            Shield shield = new Shield(-40);
            Assert.AreEqual(shield.Defense, 0);
        }

    }
}
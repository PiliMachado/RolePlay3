using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class HelmetTest
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
        public void HelmetDefenseValueTest()
        {
            Helmet helmet = new Helmet(40);
            Assert.AreEqual(helmet.Defense, 40);
        }
        /*
            Es necesiario probar la asiganción de una defensa invalida para 
            poder confirmar que el setter funciona correctamente 
        */
        [Test]
        public void HelmetDefenseInvalidTest()
        {
            Helmet helmet = new Helmet(-20);
            Assert.AreEqual(helmet.Defense, 0);
        }

    }
}
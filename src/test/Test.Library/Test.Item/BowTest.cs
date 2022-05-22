using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class BowTest
    {
        
        [SetUp]
        public void SetUp()
        {
            
        }
        /*
            Es necesiario probar la asignación de un ataque valido para
            poder confirmar que el setter funciona correctamente
        */
        [Test]
        public void BowAttackValueTest()
        {
            Bow bow = new Bow(50);
            Assert.AreEqual(bow.Attack, 50);
        }
        /*
            Es necesiario probar la asiganción de un ataque invalido para 
            poder confirmar que el setter funciona correctamente 
        */
        [Test]
        public void BowAttackInvalidTest()
        {
            Bow bow = new Bow(-35);
            Assert.AreEqual(bow.Attack, 0);
        }

    }
}
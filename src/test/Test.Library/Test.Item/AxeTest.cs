using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class AxeTest
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
        public void AxeAttackValueTest()
        {
            Axe axe = new Axe(45);
            Assert.AreEqual(axe.Attack, 45);
        }
        /*
            Es necesiario probar la asiganción de un ataque invalido para 
            poder confirmar que el setter funciona correctamente 
        */
        [Test]
        public void AxeAttackInvalidTest()
        {
            Axe axe = new Axe(-15);
            Assert.AreEqual(axe.Attack, 0);
        }

    }
}
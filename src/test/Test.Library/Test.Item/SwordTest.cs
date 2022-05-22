using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class SwordTest
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
        public void SwordAttackValueTest()
        {
            Sword sword = new Sword(45);
            Assert.AreEqual(sword.Attack, 45);
        }
        /*
            Es necesiario probar la asiganción de un ataque invalido para 
            poder confirmar que el setter funciona correctamente 
        */
        [Test]
        public void SwordAttackInvalidTest()
        {
            Sword sword = new Sword(-15);
            Assert.AreEqual(sword.Attack, 0);
        }
    }
}
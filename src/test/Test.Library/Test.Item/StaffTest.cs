using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class StaffTest
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
        public void StaffDefenseValueTest()
        {
            Staff staff = new Staff(0, 50);
            Assert.AreEqual(staff.Defense, 50);
        }
        /*
            Es necesiario probar la asiganción de una defensa invalida para 
            poder confirmar que el setter funciona correctamente 
        */
        [Test]
        public void StaffDefenseInvalidTest()
        {
            Staff staff = new Staff(0, -35);
            Assert.AreEqual(staff.Defense, 0);
        }
        /*
            Es necesiario probar la asignación de un ataque valido para
            poder confirmar que el setter funciona correctamente
        */
        [Test]
        public void StaffAttackValueTest()
        {
            Staff staff = new Staff(45, 0);
            Assert.AreEqual(staff.Attack, 45);
        }
        /*
            Es necesiario probar la asiganción de un ataque invalido para 
            poder confirmar que el setter funciona correctamente 
        */
        [Test]
        public void StaffAttackInvalidTest()
        {
            Staff staff = new Staff(-15, 0);
            Assert.AreEqual(staff.Attack, 0);
        }
    }
}
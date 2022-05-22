using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class SpellOneTest
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
        public void SpellOneDefenseValueTest()
        {
            SpellOne spellOne = new SpellOne(0, 50);
            Assert.AreEqual(spellOne.DefenseValue, 50);
        }
        /*
            Es necesiario probar la asiganción de una defensa invalida para 
            poder confirmar que el setter funciona correctamente 
        */
        [Test]
        public void SpellOneDefenseInvalidTest()
        {
            SpellOne spellOne = new SpellOne(0, -35);
            Assert.AreEqual(spellOne.DefenseValue, 0);
        }
        /*
            Es necesiario probar la asignación de un ataque valido para
            poder confirmar que el setter funciona correctamente
        */
        [Test]
        public void SpellOneAttackValueTest()
        {
            SpellOne spellOne = new SpellOne(45, 0);
            Assert.AreEqual(spellOne.AttackValue, 45);
        }
        /*
            Es necesiario probar la asiganción de un ataque invalido para 
            poder confirmar que el setter funciona correctamente 
        */
        [Test]
        public void SpellOneAttackInvalidTest()
        {
            SpellOne spellOne = new SpellOne(-15, 0);
            Assert.AreEqual(spellOne.AttackValue, 0);
        }
    }
}
using Encrypt.Bl.Algorithms;
using NUnit.Framework;

namespace Encrypt.Test
{
    [TestFixture]
    public class MorseAlgorithmTest
    {
        [Test]
        public void TestEncrypt1()
        {
            var input = "MORSE CODE";
            var decrypted = new MorseAlgorithm().Encrypt(input);
            var expected = "-- --- .-. ... . / -.-. --- -.. .";
            Assert.AreEqual(expected, decrypted);            
        }

        [Test]
        public void TestDecrypt1()
        {
            var input = "-- --- .-. ... . / -.-. --- -.. .";
            var decrypted = new MorseAlgorithm().Decrypt(input);
            var expected = "MORSE CODE";
            Assert.AreEqual(expected, decrypted);
        }

    }
}
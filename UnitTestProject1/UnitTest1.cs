using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static GG72.Fynkcya;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string text = "david is the best potato in the second world war";
            string text2 = "qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne";
            Assert.AreEqual(text, Rot13(text2));

        }
        [TestMethod]
        public void TestMethod2()
        {
            string text = "david is the best david in the second world war";
            string text2 = "qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne";
            Assert.AreNotEqual(text, Rot13(text2));

        }
        [TestMethod]
        public void TestMethod3()
        {
            string text = "       ";
            string text2 = "       ";
            Assert.AreEqual(text, Rot13(text2));

        }
        [TestMethod]
        public void TestMethod4()
        {
            string text = "david is the best potato in the second world war";
            string text2 = "qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne";
            Assert.AreEqual(text2, Rot13(text));

        }
        [TestMethod]
        public void TestMethood5()
        {
            string text = "david is the best david in the second world war";
            string text2 = "qnivq vf gur orfg cbgngb va gur frpbaq jbeyq jne";
            Assert.AreNotEqual(text2, Rot13(text));

        }
        [TestMethod]
        public void TestMethod6()
        {
            string text = "аксенова все увидит";
            string text2 = "аксенова все увидит";
            Assert.AreEqual(text, Rot13(text2));

        }
        [TestMethod]
        public void TestMethod7()
        {
            string text = "David";
            string expected = "Qnivq";
            Assert.AreEqual(expected, Rot13(text));
            Assert.AreEqual(text, Rot13(expected));
        }
        [TestMethod]
        public void TestMethod8()
        {
            string original = "Hello World";
            string once = Rot13(original);
            string twice = Rot13(once);
            Assert.AreEqual(original, twice);
        }
        [TestMethod]
        public void TestMethod9()
        {
            string text = "привет world";
            string expected = "привет jbeyq";
            Assert.AreEqual(expected, Rot13(text));
        }
        [TestMethod]
        public void TestMethod10()
        {
            string text = "hello, 123!";
            string expected = "uryyb, 123!";
            Assert.AreEqual(expected, Rot13(text));
        }
        [TestMethod]
        public void TestMethod11()
        {
            Assert.AreEqual("", Rot13(""));
        }
        [TestMethod]
        public void TestMethod12()
        {
            string text = "123!@# $%^";
            Assert.AreEqual(text, Rot13(text));
        }
        [TestMethod]
        public void TestMethod13()
        {
            string text = "DaViD";
            string expected = "QnIvQ";
            Assert.AreEqual(expected, Rot13(text));
        }
        [TestMethod]
        public void TestMethod14()
        {
            Assert.AreEqual('a', Rot13("n")[0]);
            Assert.AreEqual('z', Rot13("m")[0]);
            Assert.AreEqual('A', Rot13("N")[0]);
            Assert.AreEqual('Z', Rot13("M")[0]);
        }

        [TestMethod]
        public void TestMethod15()
        {
            string longStr = new string('a', 10000);
            string encoded = Rot13(longStr);
            Assert.AreEqual(longStr.Length, encoded.Length);
            Assert.AreEqual('n', encoded[0]);
        }

        [TestMethod]
        public void TestMethod16()
        {
            string result = Rot13(null);
            Assert.AreEqual("", result);
        }

    }
}

/*
 * [Test]
public void TestCaesarEncryptDecrypt()
{
string original = &quot;Поддержка и тестирование программных модулей&quot;;
int shift = 5;
string encrypted = CaesarCipher.Encrypt(original, shift);
string decrypted = CaesarCipher.Decrypt(encrypted, shift);
Assert.AreEqual(original, decrypted);
Assert.AreNotEqual(original, encrypted);
}*/

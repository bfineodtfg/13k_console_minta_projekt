using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _13k_console_minta_projekt;
using _13k_winform_minta_projekt;
using System.Threading.Tasks;

namespace _13k_minta_teszt
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            HttpRequests oneRequest = new HttpRequests();

            string result = await oneRequest.Login("asd", "asd");

            Assert.AreEqual(result, "Sikeres belépés, shalom!");

        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(1, 1);
        }
    }
}

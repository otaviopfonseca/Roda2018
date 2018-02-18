using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roda.Component;

namespace Roda.Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            JogoComponent.Get().ListarJogosCadastrados();
        }
    }
}

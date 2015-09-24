using System.Diagnostics;
using System.Net;
using NUnit.Framework;

namespace Demo.HelloWorld.AcceptanceTests
{
   [TestFixture]
   public class AcceptanceTests
   {
      private string _server = "nick-demo-test";

      [TestFixtureSetUp]
      public void OneTimeSetUp()
      {
         if (Debugger.IsAttached)
            _server = "localhost";
      }

      [Test]
      public void AcceptanceTest1()
      {
         var url = string.Format("http://{0}:1234/base/", _server);
         var webClient = new WebClient();
         var response = webClient.DownloadString(url);

         Assert.AreEqual("Hello World!", response);
      }
   }
}

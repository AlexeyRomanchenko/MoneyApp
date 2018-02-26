using NUnit.Framework;
using PVT.Money.Shell.Web.Models;
using System.Net;
using System.Net.Http;

namespace PVT.Money.Shell.Web.Tests
{
    [TestFixture]
    [Category("Integration tests")]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            using (HttpClient client = new HttpClient()) {
                HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:50462/");
                HttpResponseMessage response = client.SendAsync(reqMessage).Result;

                //RegisterModel model = new RegisterModel();
                //model.Login = "Alexey";
                //model.Password = "dino_0589";
                //HttpRequestMessage reqMessage2 = new HttpRequestMessage(HttpMethod.Post, "http://localhost:50462/Account/Login");
                
                Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
                string html = response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}

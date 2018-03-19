using Newtonsoft.Json;
using NUnit.Framework;
using PVT.Money.Shell.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PVT.Money.Shell.Web.Tests
{
    [TestFixture]
    [Category("Integration tests")]
    public class UnitTest1
    {
        [Test]
        public void TestLoginPage()
        {
            using (HttpClient client = new HttpClient()) {
                HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:50462/Account/Login");
                HttpResponseMessage response = client.SendAsync(reqMessage).Result;

                Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
                string html = response.Content.ReadAsStringAsync().Result;
            }
        }

        [Test]
        public void RegisterPageTests()
        {
            using (HttpClient client = new HttpClient()) {
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, "http://localhost:50462/Account/Register");
                HttpResponseMessage res = client.SendAsync(req).Result;

                Assert.AreEqual(HttpStatusCode.OK,res.StatusCode);
            }
        }

        [Test]
        public void MainRedirectTests() {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, "http://localhost:50462");
                HttpResponseMessage res = client.SendAsync(req).Result;
                string html = res.Content.ReadAsStringAsync().Result;
                Assert.AreEqual(HttpStatusCode.OK,res.StatusCode);
            }
        }

        [Test]
        public void PassingAuthorisationPasswordWrong() {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "http://localhost:50462/Account/Login");
                Dictionary<string, string> login_data = new Dictionary<string, string>();
                login_data.Add("Login","Alexey");
                login_data.Add("Password", "dino0589");
                req.Content = new FormUrlEncodedContent(login_data);

                HttpResponseMessage res = client.SendAsync(req).Result;
                Assert.AreEqual(HttpStatusCode.Unauthorized,res.StatusCode);           
            }
        }

        [Test]
        public void PassingAuthorisationPasswordOKAbout()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "http://localhost:50462/Account/Login");
                Dictionary<string, string> login_data = new Dictionary<string, string>();
                login_data.Add("Login", "Alexey");
                login_data.Add("Password", "dino_0589");
                req.Content = new FormUrlEncodedContent(login_data);

                HttpResponseMessage res = client.SendAsync(req).Result;
                Assert.AreEqual(HttpStatusCode.OK, res.StatusCode);

                HttpResponseMessage res2 = client.GetAsync("http://localhost:50462/home/about").Result;
                Assert.AreEqual(HttpStatusCode.OK, res2.StatusCode);
            }
        }

        [Test]
        public void PassingAuthorisationPasswordOKContacts()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "http://localhost:50462/Account/Login");
                Dictionary<string, string> login_data = new Dictionary<string, string>();
                login_data.Add("Login", "Alexey");
                login_data.Add("Password", "dino_0589");
                req.Content = new FormUrlEncodedContent(login_data);

                HttpResponseMessage res = client.SendAsync(req).Result;
                Assert.AreEqual(HttpStatusCode.OK, res.StatusCode);

                HttpResponseMessage res2 = client.GetAsync("http://localhost:50462/home/contact").Result;
                Assert.AreEqual(HttpStatusCode.OK, res2.StatusCode);
            }
        }

        [Test]
        public void JSonTest() {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post,"http://localhost:50462/Account/LoginExists");
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("Login","Alexxxxey");
                req.Content = new FormUrlEncodedContent(dict);


                HttpResponseMessage res = client.SendAsync(req).Result;

                var r = res.Content.ReadAsStringAsync().Result;
                bool s = JsonConvert.DeserializeObject<bool>(r);
                Assert.AreEqual(true,s);

            }
        
        }

        [Test]
        public void CurrencyJson() {
            var task = Task.Factory.StartNew(() =>
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, "http://www.nbrb.by/API/ExRates/Rates/145");
                    HttpResponseMessage res = client.SendAsync(req).Result;

                    var result = res.Content.ReadAsStringAsync().Result;
                    JsonResultObj resObject = JsonConvert.DeserializeObject<JsonResultObj>(result);
                }
            }
            );
            task.Wait();
        }
        public class JsonResultObj
        {
            [JsonProperty("Cur_ID")]
            public int CurId { get; set; }
            [JsonProperty("Cur_OfficialRate")]
            public float Rate { get; set; }
            [JsonProperty("Cur_Abbreviation")]
            public string Abbreviation { get; set; }
        }
    }
}

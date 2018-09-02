using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Text;
using System.Threading.Tasks;

namespace CC
{
    public class RequestCarbonCredits
    {
        public static void Main()
        {
            RequestCarbonCredits init = new RequestCarbonCredits();
            init.JSONName();
            init.JSONCanRelist();
            init.JSONPromotionText();
            Console.Read();
        }
        public string MakeAPICall()
        {
            RestClient rClient = new RestClient();
            rClient.endPoint = "https://api.tmsandbox.co.nz/v1/Categories/6327/Details.json?catalogue=false";
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();
            Console.WriteLine("====================================== Response ======================================");
            Console.WriteLine(strResponse);
            Console.WriteLine("====================================== Response ======================================");
            return strResponse;
        }
        [Test]        
        public void JSONName()
        {
            try
            {
                string strResponse = string.Empty;
                strResponse = MakeAPICall();                                 
                var jRaw = JsonConvert.DeserializeObject<JSONResponse>(strResponse);
                Console.WriteLine("Name is : " + jRaw.Name);
                Assert.AreEqual(jRaw.Name, "Carbon credits");
                strResponse = string.Empty;
            }           
            catch (Exception except)
            {
                Console.WriteLine("Encountered a problem : " + except.Message.ToString());
                Assert.Warn("Test cannot be completed. Encountered a problem : " + except.Message.ToString());
            }            
        }
        [Test]
        public void JSONCanRelist()
        {
            try
            {
                string strResponse = MakeAPICall();
                var jRaw = JsonConvert.DeserializeObject<JSONResponse>(strResponse);
                Console.WriteLine("CanRelist is : " + jRaw.CanRelist);
                Assert.AreEqual(jRaw.CanRelist.ToString(), "True");
            }
            catch (Exception except)
            {
                Console.WriteLine("Encountered a problem : " + except.Message.ToString());
                Assert.Warn("Test cannot be completed. Encountered a problem : " + except.Message.ToString());
            }
        }
        [Test]
        public void JSONPromotionText()
        {
            try
            {
                string strResponse = MakeAPICall();
                var jRaw = JsonConvert.DeserializeObject<JSONResponse>(strResponse);
                foreach (var prom in jRaw.Promotions)
                {
                    if (prom.Name.ToString() == "Gallery")
                    {
                        Console.WriteLine("Promotion Name: " + prom.Name.ToString());
                        Console.WriteLine("Promotion description: " + prom.Description.ToString());
                        StringAssert.Contains("2x larger image", prom.Description.ToString());
                    }
                }
            }
            catch (Exception except)
            {
                Console.WriteLine("Encountered a problem : " + except.Message.ToString());
                Assert.Warn("Test cannot be completed. Encountered a problem : " + except.Message.ToString());
            }
        }
    }
}
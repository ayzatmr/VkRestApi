using System;
using System.Collections.Specialized;
using Newtonsoft.Json;
using NUnit.Framework;
using RestApiTest.Common;
using RestApiTest.DTO;

namespace RestApiTest.AuthTests
{
    [TestFixture]
    public class AuthorizationTest
    {
        [Test]
        public void SignUp_NegativeTest()
        {
            Uri url = new Uri(ServerConstants.BaseActiveServerUri + ServerConstants.SignUp);
            NameValueCollection requestParams = Helper.SetParams("Иван", "Иванов", "", "123123Aa", "2");

            string response = Helper.DoGet(url, requestParams);
            ErrorResponse objectResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);
            Assert.AreEqual(objectResponse.error.error_code, ResponseErrorCodes.NO_PARAM);
            Assert.AreEqual(objectResponse.error.error_msg,
                "One of the parameters specified was missing or invalid: phone is undefined");
        }
        // Do not forget to change the phone number before testing
        [Test]
        public void SignUp_PositiveTest()
        {
            Uri url = new Uri(ServerConstants.BaseActiveServerUri + ServerConstants.SignUp);
            NameValueCollection requestParams = Helper.SetParams("Ivan", "Ivanov", "79510626018", "123123Aa", "2");

            string response = Helper.DoGet(url, requestParams);
            SuccessResponse objectResponse = JsonConvert.DeserializeObject<SuccessResponse>(response);
            if (objectResponse.response == null)
            {
                ErrorResponse objectResponseWithError = JsonConvert.DeserializeObject<ErrorResponse>(response);
                Console.WriteLine(objectResponseWithError.error.error_code);
                Assert.Warn("Request returned HttpStatus.OK, but with error: " + objectResponseWithError.error.error_code);
            }
            else
            {
                Assert.IsNotEmpty(objectResponse.response.sid);
            }
        }
    }
}
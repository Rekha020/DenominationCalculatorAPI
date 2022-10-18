using DenominationCalculatorAPI.Model;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace DenominationCalculatorAPITest
{
    public class DenominationControllerTestCase
    {
       // [Test]
        [TestCaseSource(nameof(DenominationServiceTestCaseValues))]
        public async Task TestDenominatioCalculatorSuccess(InputCurrency inputCurrency)
        {
            var factoryObj = new CreateServiceFactory();
            var _client = factoryObj.Create();
            MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

            var response = await _client.PostAsync("/api/DenominationCalculator/CalculateDenominations", inputCurrency, formatter);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        static InputCurrency[] DenominationServiceTestCaseValues =
       {
            new InputCurrency
            {
                Amount = 100,
                Price = 10
            }
         };

    }
}
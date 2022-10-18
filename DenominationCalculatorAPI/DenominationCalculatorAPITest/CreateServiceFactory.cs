using DenominationCalculatorAPI;
using DenominationCalculatorAPITest.Setup;
using System.Net.Http;

namespace DenominationCalculatorAPITest
{
    public class CreateServiceFactory  
    {
        private  readonly HttpClient _client;

        private readonly DenominationAPIServiceFactory<Startup> factory;

        public CreateServiceFactory()
        {
            
             factory = new DenominationAPIServiceFactory<Startup>();
            _client = factory.CreateClient();

        }

        public  HttpClient Create()
        {
            return _client;
        }
    }
}

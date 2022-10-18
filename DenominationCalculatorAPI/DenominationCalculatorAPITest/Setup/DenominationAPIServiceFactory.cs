using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace DenominationCalculatorAPITest.Setup
{
    public class DenominationAPIServiceFactory<Startup> : WebApplicationFactory<DenominationCalculatorAPI.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSetting("APPLICATIONNAME", "DenominationCalculatorAPI");


            builder.ConfigureServices(s =>
            {
                // Build the service provider.
                var sp = s.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var logger = scopedServices.GetRequiredService<ILogger<DenominationAPIServiceFactory<Startup>>>();
            });
        }


    }
}

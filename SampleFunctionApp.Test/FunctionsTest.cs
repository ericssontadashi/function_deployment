using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace SampleFunctionApp.Test
{
    public class Function1Test
    {
        private readonly ILogger logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

        [Fact]
        public async void HttpTriggerWithParams()
        {
            var request = TestFactory.CreateHttpRequest("name", "Bill");
            var response = (OkObjectResult)await Function1.Run(request, logger);
            Assert.Equal("Hello, Bill. This HTTP triggered function executed successfully.", response.Value);
        }

        [Fact]
        public async void HttpTriggerWithoutParams()
        {
            var request = TestFactory.CreateHttpRequest("", "");
            var response = (OkObjectResult)await Function1.Run(request, logger);
            Assert.Equal("This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.", response.Value);
        }
    }
}

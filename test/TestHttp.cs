using System;
using Microsoft.AspNetCore.Http;
using ExampleFunction;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace test
{
    public class TestHttp
    {
        [Fact]
        public async void CallFunction()
        {
            // create a new context and get the request object
            var context = new DefaultHttpContext();
            var req = context.Request;

            // call the function App
            var result = await Echo.Run(
                req,
                Mock.Of<ILogger>()
            );

            // Assertion - the status should be 200 - do we really need to cast to inspect?
            ((OkObjectResult)result).StatusCode.Should().Be(200);

        }
    }
}

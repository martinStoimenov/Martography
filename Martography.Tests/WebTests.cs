﻿namespace AspNetCoreTemplate.Web.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using Martography;
    using Microsoft.AspNetCore.Mvc.Testing;

    using Xunit;

    public class WebTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> server;

        public WebTests(WebApplicationFactory<Program> server)
        {
            this.server = server;
        }

        //[Fact]
        //public async Task IndexPageShouldReturnStatusCode200WithTitle()
        //{
        //    var client = this.server.CreateClient();
        //    var response = await client.GetAsync("/");
        //    response.EnsureSuccessStatusCode();
        //    var responseContent = await response.Content.ReadAsStringAsync();
        //    Assert.Contains("<title>", responseContent);
        //}

        //[Fact]
        //public async Task AdminPageRequiresAuthorization()
        //{
        //    var client = this.server.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
        //    var response = await client.GetAsync("/Administration");
        //    Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        //}
    }
}

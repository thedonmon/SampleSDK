using FluentAssertions;
using SampleSDK.Models;
using SampleSDK.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleSDK.Resource
{
    public class When_Call_GetRepo : IClassFixture<UnitTestFixture>
    {
        private readonly UnitTestFixture _fixture;
        public When_Call_GetRepo(UnitTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task And_CallSucceeds()
        {
            var response = await ApiResource.GetByUser(_fixture.GithubUser);
            response.Errors.Should().BeNull();
            response.ResponseId.Should().NotBe(new Guid());
            response.ResponseObject.Should().NotBeNull();
        }
    }
}

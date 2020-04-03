using SampleSDK.Resource;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleSDK.Tests
{
    public class UnitTestFixture : IDisposable
    {
        internal string GithubUser;
        public UnitTestFixture()
        {
            GithubUser = "thedonmon";
        }
        public void Dispose()
        {
            
        }
    }
}

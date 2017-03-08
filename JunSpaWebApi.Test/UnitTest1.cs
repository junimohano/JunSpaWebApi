using JunSpaWebApi.Controllers;
using Xunit;
using Microsoft.DotNet.PlatformAbstractions;

namespace JunSpaWebApi.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var vc = new ValuesController();
            Assert.Equal(vc.Test(), "aaa");
        }
    }
}

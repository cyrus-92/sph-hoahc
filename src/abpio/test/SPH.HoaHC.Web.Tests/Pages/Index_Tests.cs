using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace SPH.HoaHC.Pages
{
    public class Index_Tests : HoaHCWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}

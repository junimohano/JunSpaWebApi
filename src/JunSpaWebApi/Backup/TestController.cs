using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JunSpaWebApi.Backup
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    public class TestController : Controller
    {
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            return Ok(await client.GetStringAsync("http://msdn.microsoft.com"));
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id, [FromQuery, Required] string test)
        {
            return Ok($"test {id}");
        }

        //[HttpGet("{id:int}")]
        //public IActionResult Get(int id)
        //{
        //    return Ok($"test {id}");
        //}

        [HttpGet]
        [Route("haha")]
        public IActionResult GetTest([FromQuery] string a)
        {
            return Ok($"test11111111111111111111111111");
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        //[HttpPatch]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id, [FromBody] string value)
        {

        }
    }
}
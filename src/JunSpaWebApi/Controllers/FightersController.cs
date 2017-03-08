using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JunSpaWebApi.Data;
using JunSpaWebApi.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JunSpaWebApi.Controllers
{
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FightersController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            var resultString = await client.GetStringAsync(ConstValues.UfcApiFighters);

            var result = JsonConvert.DeserializeObject<List<Fighter>>(resultString);

            return Ok(result);
        }

        //[HttpGet]
        //public async Task<IActionResult> Get(string name)
        //{
        //    var client = new HttpClient();
        //    var resultString = await client.GetStringAsync(ConstValues.UfcApiFighters);

        //    var result = JsonConvert.DeserializeObject<List<Fighter>>(resultString);
        //    var resultByName = result.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name));

        //    return Ok(resultByName);
        //}

    }
}

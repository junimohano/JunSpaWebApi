using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JunSpaWebApi.Data;
using JunSpaWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JunSpaWebApi.Controllers
{
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OctagonGirlsController : Controller
    {
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            var resultString = await client.GetStringAsync(ConstValues.UfcApiOctagonGirls);

            var result = JsonConvert.DeserializeObject<List<OctagonGirlDto>>(resultString);

            return Ok(result);
        }
        
    }
}

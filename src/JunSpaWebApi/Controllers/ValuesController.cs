using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace JunSpaWebApi.Controllers
{
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = new string[] { };
            await Task.Run(() =>
            {
                Task.Delay(1000);
                data = new string[] { "value1", "value2" };
            });

            return Ok(data);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = string.Empty;
            await Task.Run(() =>
            {
                data = $"get data : {id}";
            });

            return Ok(data);
        }

        public string Test()
        {
            return "aaa";
        }

        // GET api/values/5
        [Authorize]
        [HttpGet]
        [Route("test")]
        public string GetTest()
        {
            const string data = "test";

            return data;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

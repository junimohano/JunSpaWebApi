using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
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
            try
            {
                var client = new HttpClient();
                var resultString = await client.GetStringAsync(ConstValues.UfcApiFighters);

                var result = JsonConvert.DeserializeObject<List<Fighter>>(resultString);

                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return NotFound();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var doc = await GetHtmlDocument($"{ConstValues.UfcApiFighters}/{id}");

                var fightersDetail = new FighterDetail();

                var selectNodes = doc.DocumentNode.SelectNodes("//table[contains(@class, 'fight-info-data')]");
                if (selectNodes != null)
                {
                    foreach (var selectNode in selectNodes)
                    {
                        var from = selectNode.ChildNodes[1].ChildNodes[1].ChildNodes[3].InnerText;
                        var fightsOutOf = selectNode.ChildNodes[1].ChildNodes[3].ChildNodes[3].InnerText;
                        var age = selectNode.ChildNodes[1].ChildNodes[5].ChildNodes[3].InnerText;
                        var height = selectNode.ChildNodes[1].ChildNodes[7].ChildNodes[3].InnerText;
                        var weight = selectNode.ChildNodes[1].ChildNodes[9].ChildNodes[3].InnerText;
                        var weightClass = selectNode.ChildNodes[1].ChildNodes[11].ChildNodes[3].InnerText;

                        fightersDetail.From = from;
                        fightersDetail.FightsOutOf = fightsOutOf;
                        fightersDetail.Age = Convert.ToInt32(age);
                        fightersDetail.Height = height;
                        fightersDetail.Weight = weight;
                        fightersDetail.WeightClass = weightClass;
                    }
                }

                selectNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'ring fighter-skill-chart')]");
                if (selectNodes != null)
                {
                    foreach (var recommendNode in selectNodes)
                    {
                        var striking = recommendNode.ChildNodes[1].Attributes["data-striking"].Value;
                        var submissions = recommendNode.ChildNodes[1].Attributes["data-submissions"].Value;
                        var takedowns = recommendNode.ChildNodes[1].Attributes["data-takedowns"].Value;

                        fightersDetail.Striking = Convert.ToDouble(striking);
                        fightersDetail.Submissions = Convert.ToDouble(submissions);
                        fightersDetail.Takedowns = Convert.ToDouble(takedowns);
                    }
                }

                return Ok(fightersDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NotFound();
        }

        private async Task<HtmlDocument> GetHtmlDocument(string address)
        {
            using (var client = new HttpClient())
            {
                var baseUri = address;
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();

                var response = await client.GetAsync(baseUri);
                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();

                    var doc = new HtmlDocument();
                    doc.Load(responseStream);

                    //string html = doc.DocumentNode.OuterHtml;

                    return doc;
                }
            }
            return null;
        }

    }
}

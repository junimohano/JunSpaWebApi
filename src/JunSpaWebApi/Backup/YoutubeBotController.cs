using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JunSpaWebApi.Backup
{
    [Route("api/[controller]")]
    public class YoutubeBotController : Controller
    {
        [HttpGet]
        public async Task<bool> RunYoutubeViews(string url, int index)
        {
            try
            {
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("[ultimate destination of your request]");
                //WebProxy myproxy = new WebProxy("[your proxy address]", [your proxy port number]);
                //myproxy.BypassProxyOnLocal = false;
                //request.Proxy = myproxy;
                //request.Method = "GET";
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                //Uri proxyUrl = WebRequest.DefaultWebProxy.GetProxy(new Uri("https://github.com/"));

                //var addressSplit = ProxySetting.ProxyList[proxyIndex].Split(':');

                UriBuilder uri;
                uri = new UriBuilder("197.254.106.226");
                uri.Port = 8080;

                var config = new HttpClientHandler
                {
                    UseProxy = true,
                    Proxy = new JunProxy(uri.Uri)
                };

                using (var http = new HttpClient(config))
                {
                    var result = await http.GetAsync(url);
                    Console.WriteLine($"Result: {result}");
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }
    }
}

using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DeteccaoPessoas.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using DeteccaoPessoas.Helpers;

namespace DeteccaoPessoas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public async Task<IActionResult> SnapImage(IFormFile webcam)
        {
            var client = new HttpClient();
            
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Constantes.ApiVisaoComputacional);

            const string uri = Constantes.ApiVisaoComputacional;

            using (var ms = new MemoryStream())
            {
                webcam.CopyTo(ms);
                var fileBytes = ms.ToArray();
                
                using (var content = new ByteArrayContent(fileBytes))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    var response = await client.PostAsync(uri, content);
                    
                    var statusCode = response.StatusCode;

                    if (statusCode != HttpStatusCode.OK)
                        return BadRequest(response.Content);

                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    var retorno = JsonConvert.DeserializeObject<DetectedObject>(responseContent);

                    return Ok(retorno);
                }
            }
        }
    }
}
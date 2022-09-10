using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestAPI.ModelViews;
using RestSharp;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTest : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var baseUrl = "https://mocki.io/v1/";
            var client = new RestClient(baseUrl);
            var request = new RestRequest("d4867d8b-b5d5-4a48-a4ab-79131b5809b8", Method.Get);
            var res = client.Execute(request);
            if (res.IsSuccessful)
            {
                var content = res.Content;
                var mappedResult = JsonConvert.DeserializeObject<List<RestResult>>(content);
                return Ok(mappedResult);
            }

            return Ok();

        }
    }
}

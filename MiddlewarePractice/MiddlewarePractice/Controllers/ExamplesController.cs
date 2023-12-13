using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddlewarePractice.Filters;
using System.Net.Http;

namespace MiddlewarePractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamplesController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ExamplesController()
        {
            _httpClient = new HttpClient();
        }
        [HttpGet]
        [Route("ExampleActionFilter")]
        [ExampleActionFilter(Order = 1)]
        public IActionResult ActionResult(string newContent = "")
        {
            return Ok(newContent + "\nWelcome");
        }
        [HttpGet]
        [Route("HttpClientExample")]
        public async Task<IActionResult> HttpClientExampleAsync()
        {
            string apiUrl = "https://localhost:44359/api/TestAll/GetAllStudents";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                return Ok(responseData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error occurred while fetching data");
            }
        }
    }
}

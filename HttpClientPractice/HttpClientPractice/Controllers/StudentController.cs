using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using WebAPI1.Models;

namespace HttpClientPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:44359/api/TestAll/";
        public StudentController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var apiUrl = _baseUrl + "GetAllStudents";
                var response = await _httpClient.GetAsync(apiUrl);
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error while calling the external API: {ex.Message}");
            }
        }
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody]Student student)
        {
            try
            {
                var apiUrl = _baseUrl + "AddStudent";
                string jsonContent = JsonConvert.SerializeObject(student);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    return Ok("Student added successfully in the other API");
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error while calling the external API: {ex.Message}");
            }
        }
        [HttpGet("GetStudent")]
        public async Task<IActionResult> GetStudent(int Id)
        {
            try
            {
                var apiUrl = _baseUrl + "GetStudent?Id=" + Id;
                var response = await _httpClient.GetAsync(apiUrl);
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error while calling the external API: {ex.Message}");
            }
        }
        [HttpPut("ChangeStudent")]
        public async Task<IActionResult> ChangeStudent(int Id, [FromBody] Student newStudent)
        {
            try
            {
                var apiUrl = _baseUrl + "ChangeStudent?Id=" + Id;
                string jsonContent = JsonConvert.SerializeObject(newStudent);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync(apiUrl, content); if (response.IsSuccessStatusCode)
                {
                    return Ok("Student Changed successfully in the other API");
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error while calling the external API: {ex.Message}");
            }
        }
        [HttpPatch("RenameStudent")]
        public async Task<IActionResult> RemaneStudent([FromQuery] int Id, string Name)
        {
            try
            {
                var apiUrl = _baseUrl + $"RenameStudent?Id={Id}&Name={Name}";
                HttpResponseMessage response = await _httpClient.PatchAsync(apiUrl, null); 
                if (response.IsSuccessStatusCode)
                {
                    return Ok("Student Name Changed successfully in the other API");
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error while calling the external API: {ex.Message}");
            }
        }
        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            try
            {
                var apiUrl = _baseUrl + $"DeleteStudent?Id={Id}";
                HttpResponseMessage response = await _httpClient.DeleteAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    return Ok("Student Deleted successfully in the other API");
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error while calling the external API: {ex.Message}");
            }
        }
    }
}

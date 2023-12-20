using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project5.Data;
using Project5.Models;

namespace Project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContex _dbContext;
        public CategoryController(DataContex dataContex)
        {
            _dbContext = dataContex;
        }
        [Authorize(Roles = "Vendor")]
        [HttpPost("AddCategory")]
        public IActionResult AddCategory(string categoryName)
        {
            try
            {
                if(_dbContext.Categories.Any(x => x.CategoryName == categoryName))
                {
                    return BadRequest("Category already exist.");
                }
                Category category = new Category();
                category.CategoryName = categoryName;
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return Ok("Category added sucessfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            try
            {
                var categories = _dbContext.Categories.Select(x => new {x.CategoryId, x.CategoryName});
                if (categories.Any())
                {
                    return Ok(categories);
                }
                return BadRequest("No Categories Found.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

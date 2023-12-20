using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project5.Data;
using Project5.Models;
using System.Security.Claims;

namespace Project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContex _dbContext;
        public ProductController(DataContex dataContex)
        {
            _dbContext = dataContex;
        }
        [Authorize(Roles = "Vendor")]
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(string productName, double price, int categoryId,[FromForm] IFormFile image)
        {
            try
            {
                if (!_dbContext.Categories.Any(x => x.CategoryId == categoryId))
                {
                    return BadRequest("Category not exist.");
                }
                Product product = new Product();
                product.ProductName = productName;
                product.Price = price;
                product.CategoryId = categoryId;
                product.VendorId = GetCurrentUserId();
                string imagePath = await ProcessImageFile(image);
                product.ImagePath = imagePath;
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return Ok("Product added sucessfully.");
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex);
            }
        }
        [Authorize]
        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                if (_dbContext.Products.Any())
                {
                    var products = _dbContext.Products.Join(_dbContext.Categories,
                                                        product => product.CategoryId,
                                                        category => category.CategoryId,
                                                        (product, category) => new { product, category.CategoryName })
                                                      .Join(_dbContext.Users.Where(x => x.IsActive),
                                                            product => product.product.VendorId,
                                                            user => user.UserId,
                                                            (product, user) =>
                                                            new {
                                                                product.product.ProductId,
                                                                product.product.ProductName,
                                                                product.product.Price,
                                                                product.product.ImagePath,
                                                                product.product.CategoryId,
                                                                product.CategoryName,
                                                                product.product.VendorId,
                                                                VendorName = user.UserName
                                                            }
                                                        );
                    return Ok(products);
                }
                return BadRequest("No products.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpGet("GetProductsByCategoryId")]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            try
            {
                if(!_dbContext.Categories.Where(x => x.CategoryId == categoryId).Any())
                {
                    return BadRequest("No Category Exist.");
                }
                if(!_dbContext.Products.Where(x => x.CategoryId == categoryId).Any())
                {
                    return BadRequest("No Product Found.");
                }
                var products = _dbContext.Products.Join(_dbContext.Categories.Where(x => x.CategoryId == categoryId),
                                                        product => product.CategoryId,
                                                        category => category.CategoryId,
                                                        (product, category) => new { product, category.CategoryName })
                                                      .Join(_dbContext.Users.Where(x => x.IsActive),
                                                            product => product.product.VendorId,
                                                            user => user.UserId,
                                                            (product, user) =>
                                                            new {
                                                                product.product.ProductId,
                                                                product.product.ProductName,
                                                                product.product.Price,
                                                                product.product.ImagePath,
                                                                product.product.CategoryId,
                                                                product.CategoryName,
                                                                product.product.VendorId,
                                                                VendorName = user.UserName
                                                            }
                                                        );
                return Ok( products );
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "Vendor")]
        [HttpGet("GetProductsByVendor")]
        public IActionResult GetProductsByVendor()
        {
            try
            {
                int userId = GetCurrentUserId();
                if (!_dbContext.Products.Where(x => x.VendorId == userId).Any())
                {
                    return BadRequest("No Product Found.");
                }
                var products = _dbContext.Products.Join(_dbContext.Categories,
                                                        product => product.CategoryId,
                                                        category => category.CategoryId,
                                                        (product, category) => new { product, category.CategoryName })
                                                      .Join(_dbContext.Users.Where(x => x.IsActive && x.UserId == userId),
                                                            product => product.product.VendorId,
                                                            user => user.UserId,
                                                            (product, user) =>
                                                            new {
                                                                product.product.ProductId,
                                                                product.product.ProductName,
                                                                product.product.Price,
                                                                product.product.ImagePath,
                                                                product.product.CategoryId,
                                                                product.CategoryName,
                                                                product.product.VendorId,
                                                                VendorName = user.UserName
                                                            }
                                                        );
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        private int GetCurrentUserId()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var userClaims = identity.Claims;
                var email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
                int id = _dbContext.Users.First(x => x.Email == email).UserId;
                return id;
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }
        private async Task<string> ProcessImageFile(IFormFile image)
        {
            try
            {
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string imagePath = Path.Combine("Uploads", uniqueFileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                return "Uploads/" + uniqueFileName;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
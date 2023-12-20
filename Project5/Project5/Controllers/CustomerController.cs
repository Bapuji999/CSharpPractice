using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project5.Data;
using Project5.Models;
using System.Security.Claims;

namespace Project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContex _dbContext;
        public CustomerController(DataContex dataContex)
        {
            _dbContext = dataContex;
        }
        [Authorize(Roles = "Customer")]
        [HttpPost("AddCustomerIntrest")]
        public IActionResult AddCustomerIntrest(int productId)
        {
            try
            {
                if(!_dbContext.Products.Any(x => x.ProductId == productId))
                {
                    return BadRequest("Invalid Product Id.");
                } 
                int userId = GetCurrentUserId();
                if(_dbContext.CustomerIntrests.Any(x => x.ProductId == productId && x.CustomerId == userId))
                {
                    return BadRequest("Customer Intrest already present.");
                }
                CustomerIntrest customerIntrest = new CustomerIntrest();
                customerIntrest.ProductId = productId;
                customerIntrest.CustomerId = userId;
                _dbContext.Add(customerIntrest);
                _dbContext.SaveChanges();
                return Ok("CustomerIntrest saved sucessfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Customer")]
        [HttpGet("GetCustomerIntrest")]
        public IActionResult GetCustomerIntrest()
        {
            try
            {
                int userId = GetCurrentUserId();
                if (!_dbContext.CustomerIntrests.Any(x => x.CustomerId == userId))
                {
                    return BadRequest("No Intrest already present.");
                }
                var intrests = _dbContext.CustomerIntrests.Where(x => x.CustomerId == userId)
                                                          .Join(_dbContext.Products, ci => ci.ProductId, p => p.ProductId,
                                                                 (ci, p) => new { ci, p })
                                                          .Join(_dbContext.Categories,
                                                                 product => product.p.CategoryId,
                                                                 category => category.CategoryId,
                                                                 (product, category) => new { product, category.CategoryName })
                                                          .Join(_dbContext.Users.Where(x => x.IsActive),
                                                                 product => product.product.p.VendorId,
                                                                 user => user.UserId,
                                                                 (product, user) =>
                                                                 new
                                                                 {
                                                                     product.product.p.ProductId,
                                                                     product.product.p.ProductName,
                                                                     product.product.p.Price,
                                                                     product.product.p.Rating,
                                                                     product.product.p.ImagePath,
                                                                     product.product.p.CategoryId,
                                                                     product.CategoryName,
                                                                     product.product.p.VendorId,
                                                                     VendorName = user.UserName
                                                                 });
                return Ok(intrests);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private int GetCurrentUserId()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var userClaims = identity?.Claims;
                var email = userClaims?.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value;
                int id = _dbContext.Users.First(x => x.Email == email).UserId;
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}

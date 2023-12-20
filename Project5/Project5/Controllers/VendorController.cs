using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project5.Data;
using Project5.Models;

namespace Project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly DataContex _dbContext;
        public VendorController(DataContex dataContex)
        {
            _dbContext = dataContex;
        }
        [Authorize]
        [HttpGet("GetVendors")]
        public IActionResult GetVendors()
        {
            try
            {
                var vendorRollId = _dbContext.UserRolls.First(x => x.RollType == "Vendor").RollId;
                if (!_dbContext.Users.Where(x => x.RollId == vendorRollId && x.IsActive).Any())
                {
                    return BadRequest("No Vendor exist.");
                }
                var vendors = _dbContext.Users.Where(x => x.RollId == vendorRollId && x.IsActive)
                                              .Select(x => new {vendorId = x.UserId, vendorName = x.UserName });
                return Ok(vendors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("GetVendorDetailById")]
        public IActionResult GetVendorDetailById(int vendorId)
        {
            try
            {
                var vendorRollId = _dbContext.UserRolls.First(x => x.RollType == "Vendor").RollId;
                if (!_dbContext.Users.Any(x => x.RollId == vendorRollId && x.UserId == vendorId && x.IsActive))
                {
                    return BadRequest("No Vendor exist.");
                }
                var vendor = _dbContext.Users.Single(x => x.RollId == vendorRollId && x.UserId == vendorId && x.IsActive);
                var products = _dbContext.Products.Where(x => x.VendorId == vendor.UserId)
                                                  .Select(x => new
                                                  {
                                                      productId = x.ProductId,
                                                      productName = x.ProductName,
                                                      price = x.Price,
                                                      rating = x.Rating,
                                                      imagePath = x.ImagePath,
                                                      categoryId = x.CategoryId,
                                                      categoryName = _dbContext.Categories.Single(x => x.CategoryId == x.CategoryId).CategoryName
                                                  });
                var vendorDetail = new
                {
                    VendorId = vendor.UserId,
                    VendorName = vendor.UserName,
                    VendorEmail = vendor.Email,
                    VendorPhone = vendor.Phone,
                    Products = products
                };
                return Ok(vendorDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

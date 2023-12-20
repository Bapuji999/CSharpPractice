using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project5.Data;
using Project5.Models;

namespace Project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContex _dbContext;
        public AdminController(DataContex dataContex)
        {
            _dbContext = dataContex;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetCustomers")]
        public IActionResult GetCustomers()
        {
            try
            {
                var customerRollId = _dbContext.UserRolls.Single(x => x.RollType == "Customer").RollId;
                if (!_dbContext.Users.Any(x=> x.RollId == customerRollId && x.IsActive))
                {
                    return BadRequest("No Customer registered yet.");
                }
                var Customers = _dbContext.Users.Where(x => x.RollId == customerRollId && x.IsActive)
                                                .Select(x => new
                                                {
                                                    CustomerId = x.UserId,
                                                    CustomerName = x.UserName,
                                                    CustomerEmail = x.Email,
                                                    CustomerPhone = x.Phone
                                                });
                return Ok(Customers);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("DeativateCustomer")]
        public IActionResult DeativateCustomer(int customerId)
        {
            try
            {
                var customerRollId = _dbContext.UserRolls.Single(x => x.RollType == "Customer").RollId;
                if (!_dbContext.Users.Any(x => x.RollId == customerRollId && x.IsActive && x.UserId == customerId))
                {
                    return BadRequest("No Customer found for given id.");
                }
                var customer = _dbContext.Users.Single(x => x.RollId == customerRollId && x.IsActive && x.UserId == customerId);
                customer.IsActive = false;
                _dbContext.Update(customer);
                _dbContext.SaveChanges();
                return Ok("Customer Deactivated sucessfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("DeativateVendor")]
        public IActionResult DeativateVendor(int vendorId)
        {
            try
            {
                var VendorRollId = _dbContext.UserRolls.Single(x => x.RollType == "Vendor").RollId;
                if (!_dbContext.Users.Any(x => x.RollId == VendorRollId && x.IsActive && x.UserId == vendorId))
                {
                    return BadRequest("No Customer found for given id.");
                }
                var vendor = _dbContext.Users.Single(x => x.RollId == VendorRollId && x.IsActive && x.UserId == vendorId);
                vendor.IsActive = false;
                _dbContext.Update(vendor);
                _dbContext.SaveChanges();
                return Ok("Vendor Deactivated sucessfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("AddVendor")]
        public IActionResult AddVendor(string userName, string phone, string email, string password)
        {
            try
            {
                if(_dbContext.Users.Any(x => x.Email == email))
                {
                    return BadRequest("Email already exist.");
                }
                if (_dbContext.Users.Any(x => x.Phone == phone))
                {
                    return BadRequest("Phone number already exist.");
                }
                User user = new User();
                user.UserName = userName;
                user.Phone = phone;
                user.Email = email;
                user.Password = password;
                user.RollId = _dbContext.UserRolls.Single(x => x.RollType == "Vendor").RollId;
                _dbContext.Add(user);
                _dbContext.SaveChanges();
                return Ok("Vendor added sucessfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(string userName, string phone, string email, string password)
        {
            try
            {
                if (_dbContext.Users.Any(x => x.Email == email))
                {
                    return BadRequest("Email already exist.");
                }
                if (_dbContext.Users.Any(x => x.Phone == phone))
                {
                    return BadRequest("Phone number already exist.");
                }
                User user = new User();
                user.UserName = userName;
                user.Phone = phone;
                user.Email = email;
                user.Password = password;
                user.RollId = _dbContext.UserRolls.Single(x => x.RollType == "Customer").RollId;
                _dbContext.Add(user);
                _dbContext.SaveChanges();
                return Ok("Customer added sucessfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

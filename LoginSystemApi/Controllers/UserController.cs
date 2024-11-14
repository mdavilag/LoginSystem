using LoginSystemApi.Data;
using LoginSystemApi.DTO;
using LoginSystemApi.Models;
using LoginSystemApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace LoginSystemApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserService _service;

        public UserController(DataContext context, UserService service) {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try{
                return Ok(_context.Users.ToList());
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null) return Ok(user);

            else return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);


            try
            {
                var created = await _service.RegisterUser(userDto);

                if (created) return Ok("User registered");
                else return BadRequest("Failed to register the user");
                
            }catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
    }
}

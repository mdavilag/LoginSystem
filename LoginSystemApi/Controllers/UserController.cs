using LoginSystemApi.Data;
using LoginSystemApi.DTO;
using LoginSystemApi.Models;
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

        public UserController(DataContext context) {
            _context = context;
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
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            var newUser = new UserModel();
            try
            {
                newUser.Cpf = userDto.Cpf;
                newUser.Name = userDto.Name;
                newUser.Email = userDto.Email;
                newUser.PasswordHash = userDto.Password; //Implementar hash+salt

                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

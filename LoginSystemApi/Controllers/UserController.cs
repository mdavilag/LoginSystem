using LoginSystemApi.Data;
using LoginSystemApi.DTO;
using LoginSystemApi.Models;
using LoginSystemApi.Services;
using LoginSystemApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using SQLitePCL;

namespace LoginSystemApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
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
                var users = await _context.Users
                    .Include(x=>x.UserRoles)
                    .ThenInclude(x=>x.Role)
                    .ToListAsync();
                return Ok(new ResultViewModel<List<UserModel>>(users));
            }
            catch(Exception ex){
                return BadRequest(new ResultViewModel<UserModel>(ex.Message));
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null) return Ok(new ResultViewModel<UserModel>(user));

            else return NotFound(new ResultViewModel<UserModel>("Usuário não encontrado"));

        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            if(!ModelState.IsValid) return BadRequest(new ResultViewModel<UserModel>("ModelState não é válido"));


            try
            {
                var created = await _service.RegisterUser(userDto);

                if (created) return Ok(new ResultViewModel<string>("Criado com sucesso"));
                else return BadRequest(new ResultViewModel<UserModel>("Erro ao registrar usuário"));
                
            }catch (Exception ex)
            {
                return BadRequest(new ResultViewModel<UserModel>(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateDto userDto)
        {
            //

            if (!ModelState.IsValid) return BadRequest(new ResultViewModel<UserModel>("ModelState não é válido"));

            var updateResult = await _service.UpdateUserAsync(id, userDto);
            if (updateResult.Errors.Any())
            {
                return BadRequest(new ResultViewModel<UserModel>(updateResult.Errors[0]));
            }
            else
            {
                return Ok(updateResult);
            }

        }

    }
}

using LoginSystemApi.Data;
using LoginSystemApi.DTO;
using LoginSystemApi.Models;

namespace LoginSystemApi.Services
{
    public class UserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async bool RegisterUser(UserRegisterDto userDto)
        {
            var user = new UserModel()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Cpf = userDto.Cpf,
                PasswordHash = userDto.Password // Need to increment Hash logic
            };
            var userRole = _context.Roles.FirstOrDefault(x=>x.Id == 0);
            user.Roles.Add(userRole);
            

        }
    }
}

using LoginSystemApi.Data;
using LoginSystemApi.DTO;
using LoginSystemApi.Models;
using Microsoft.AspNetCore.Identity;
using SecureIdentity.Password;

namespace LoginSystemApi.Services
{
    public class UserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUser(UserRegisterDto userDto)
        {
            var user = new UserModel()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Cpf = userDto.Cpf,
                PasswordHash = PasswordHasher.Hash(userDto.Password)
            };
            var userRole = _context.Roles.FirstOrDefault(x=>x.Id == 0);
            user.Roles.Add(userRole);



            return true;
        }
    }
}

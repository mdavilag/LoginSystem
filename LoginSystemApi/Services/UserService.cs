using LoginSystemApi.Data;
using LoginSystemApi.DTO;
using LoginSystemApi.Models;
using Microsoft.EntityFrameworkCore;
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
            try
            {   // Check if user already exists
                if (await _context.Users.AnyAsync(x => x.Email == userDto.Email || x.Cpf == userDto.Cpf))
                {
                    Console.WriteLine("Email ou Cpf já cadastrado");
                    return (false);
                }

                // Create and map userDto to user
                var user = new UserModel()
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Cpf = userDto.Cpf,
                    PasswordHash = PasswordHasher.Hash(userDto.Password)
                };

                // Search for the Role "User" and adds into the new user roles

                // To implement

                //var userRole = await _context.Roles.FirstOrDefaultAsync(x=>x.Name == "User");
                //if (userRole==null) return false;

                //user.Roles.Add(userRole);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false; // Needs improvement
            }



        }
    }
}

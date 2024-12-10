using LoginSystemApi.Data;
using LoginSystemApi.DTO;
using LoginSystemApi.Models;
using LoginSystemApi.Utils.Validators;
using LoginSystemApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using System.Security.Cryptography.X509Certificates;

namespace LoginSystemApi.Services
{
    public class UserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        

        public async Task<bool> RegisterUser(UserRegisterDto userDto) // Return here to improve error handling
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
                    PasswordHash = PasswordHasher.Hash(userDto.Password)
                };

                // Validate and add User Cpf
                if (CpfValidator.IsValid(CpfValidator.CleanCpf(userDto.Cpf)))
                {
                    user.Cpf = CpfValidator.CleanCpf(userDto.Cpf);

                }
                else
                {
                    return (false);
                }

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Search for role "user"
                var userRole = await _context.Roles.FirstOrDefaultAsync(x => x.Name == "User");
                if (userRole == null) return false;

                var userRoleModel = new UserRoleModel
                {
                    User = user,
                    Role = userRole
                };

                _context.UserRoles.Add(userRoleModel);
                await _context.SaveChangesAsync();

                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false; // Needs improvement
            }

            
        } 
        
        public async Task<ResultViewModel<UserModel>> UpdateUserAsync(int id, UserUpdateDto userDto)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userToUpdate == null) return new ResultViewModel<UserModel>("Id do usuário não encontrado");
            try
            {
                if(!string.IsNullOrEmpty(userDto.Name))
                {
                    userToUpdate.Name = userDto.Name;
                }
                if (!string.IsNullOrEmpty(userDto.Email))
                {
                    if(userDto.Email != userToUpdate.Email)
                    {
                        // Verify if email already exists             
                        if(_context.Users.Any(x=>x.Email == userDto.Email))
                        {
                            return new ResultViewModel<UserModel>("Esse e-mail já está cadastrado em outro usuário");
                        }
                        else
                        {
                            userToUpdate.Email = userDto.Email;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(userDto.Password))
                {
                    userToUpdate.PasswordHash = PasswordHasher.Hash(userDto.Password);
                }
                if (!string.IsNullOrEmpty(userDto.Cpf))
                {
                    // Verify if cpf is valid and if already exists
                    if(userDto.Cpf != userToUpdate.Cpf)
                    {
                        if(!CpfValidator.IsValid(userDto.Cpf))
                        {
                            return new ResultViewModel<UserModel>("CPF não é válido");
                        }
                        else if(_context.Users.Any(x=>x.Cpf == userDto.Cpf))
                        {
                            return new ResultViewModel<UserModel>("Esse CPF já está cadastrado em outro usuário");
                        }
                        else
                        {
                            userToUpdate.Cpf = userDto.Cpf;
                        }
                    }
                }
                if (userDto.IsActive != null)
                {
                    userToUpdate.IsActive = (bool)userDto.IsActive;
                }
                _context.SaveChangesAsync();

                return new ResultViewModel<UserModel>(userToUpdate);
            }catch(Exception ex)
            {
                return new ResultViewModel<UserModel>("Error: " + ex.Message);
            }



        }
    }
    
}

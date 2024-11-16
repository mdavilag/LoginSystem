﻿using LoginSystemApi.Data;
using LoginSystemApi.DTO;
using LoginSystemApi.Models;
using LoginSystemApi.Utils.Validators;
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
                if(CpfValidator.IsValid(CpfValidator.CleanCpf(userDto.Cpf)))
                {
                    user.Cpf = CpfValidator.CleanCpf(userDto.Cpf);

                }
                else
                {
                    return (false);
                }

                // Search for the Role "User" and adds into the new user roles

                // To implement

                var userRole = await _context.Roles.FirstOrDefaultAsync(x => x.Name == "User");
                if (userRole == null) return false;

                _context.Users.Add(user);

                user.UserRoles.Add(new UserRoleModel()
                {
                    UserId = user.Id,
                    RoleId = userRole.Id
                });

                await _context.SaveChangesAsync();

                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false; // Needs improvement
            }

            
        } 
        
        //public async Task<bool> UpdateUser()
        //{

        //}
        
    }
}

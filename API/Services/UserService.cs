using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.DTO;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService
    {
        private readonly StoreContext _context;

        public UserService(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> CreateUserAsync(UserRegistrationDTO user)
        {

            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Height = user.Height,
                Weight = user.Weight,
                DOB = user.DOB
            };

            object value = _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UpdateUserAsync(UserUpdateDTO user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);

            // Update the properties of the existing user entity
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Height = user.Height;
            existingUser.Weight = user.Weight;
            existingUser.DOB = user.DOB;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
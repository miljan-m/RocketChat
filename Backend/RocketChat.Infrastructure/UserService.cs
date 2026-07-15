using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RocketChat.Application.DTOs.UserDTOs;
using RocketChat.Application.Interfaces;
using RocketChat.Infrastructure;

namespace RocketChat.Application.Services
{

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserDTO?> CreateUser(CreateUserDTO createUserDTO)
        {
            var result = await _userManager.CreateAsync(_mapper.Map<ApplicationUser>(createUserDTO), createUserDTO.Password);
            if (result.Succeeded) return createUserDTO;
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.Description);
            }
            return null;
        }
        public async Task<GetUserDTO?> DeleteUser(Guid Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            if (user == null) return null;
            await _userManager.DeleteAsync(user);
            return _mapper.Map<GetUserDTO>(user);
        }

        public async Task<IEnumerable<GetUserDTO>?> GetAllUsers()
        {
            var result = await _userManager.Users.ToListAsync();
            if (result.Count == 0) return null;
            var mappedUsers = result.Select(_mapper.Map<GetUserDTO>);
            return mappedUsers;
        }

        public async Task<GetUserDTO?> GetUser(Guid Id)
        {
            var result = await _userManager.FindByIdAsync(Id.ToString());
            if (result == null) return null;
            return _mapper.Map<GetUserDTO>(result);
        }

        public async Task<string?> GetUserIdByUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user?.Id.ToString();

        }

        public Task<UpdateUserDTO> UpdateUser(Guid Id, UpdateUserDTO updateUserDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserDTO> GetUserByUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username) ?? throw new Exception();
            return _mapper.Map<GetUserDTO>(user);
        }



    }
}
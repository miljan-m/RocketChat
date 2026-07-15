using RocketChat.Application.DTOs.UserDTOs;

namespace RocketChat.Application.Interfaces
{
    public interface IUserService
    {
        public Task<GetUserDTO?> GetUser(Guid Id);
        public Task<IEnumerable<GetUserDTO>?> GetAllUsers();

        public Task<CreateUserDTO?> CreateUser(CreateUserDTO createUserDTO);

        public Task<GetUserDTO?> DeleteUser(Guid Id);

        public Task<UpdateUserDTO> UpdateUser(Guid Id, UpdateUserDTO updateUserDTO);

        public Task<string?> GetUserIdByUserName(string username);

        public Task<GetUserDTO> GetUserByUserName(string username);

    }
}
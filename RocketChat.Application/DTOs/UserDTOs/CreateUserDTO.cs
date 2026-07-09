namespace RocketChat.Application.DTOs.UserDTOs
{
    public record CreateUserDTO
    (
        string UserName,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Address,
        string Password
    );
}
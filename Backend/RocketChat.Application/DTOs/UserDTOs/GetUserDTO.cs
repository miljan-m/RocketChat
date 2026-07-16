namespace RocketChat.Application.DTOs.UserDTOs
{
    public record GetUserDTO
    (
        string FirstName,
        string LastName,
        string UserName,
        string Email,
        string PhoneNumber,
        string Address
    );
}
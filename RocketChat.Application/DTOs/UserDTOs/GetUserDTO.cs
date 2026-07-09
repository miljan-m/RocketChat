namespace RocketChat.Application.DTOs.UserDTOs
{
    public record GetUserDTO
    (
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Address
    );
}
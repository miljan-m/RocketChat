namespace RocketChat.Application.DTOs.UserDTOs
{
    public record UpdateUserDTO(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Address
    );
}
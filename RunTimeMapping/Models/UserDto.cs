namespace RunTimeMapping.Models;

public class UserDto
{
    public string? Username { get; set; }
    public string? FullName { get; set; }
    public string? Age { get; set; }
    public AddressDto? Address { get; set; }
}
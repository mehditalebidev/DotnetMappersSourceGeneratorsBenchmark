using Riok.Mapperly.Abstractions;
namespace RunTimeMapping.Models.MapperlyMappers;

[Mapper]
public partial class UserMapper
{
    public UserDto Map(User user)
    {
        return new UserDto()
        {
            Username = user.Username,
            Age = user.Age.ToString(),
            FullName = $"{user.FirstName} {user.LastName}",
            Address = user.Address == null ? null : new AddressDto()
            {
                City = user.Address.City,
                ZipCode = user.Address.ZipCode,
                Street = user.Address.Street,
                Apartment = user.Address.Apartment
            }
        };
    }
}
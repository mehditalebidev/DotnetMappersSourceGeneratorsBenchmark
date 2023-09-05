using RunTimeMapping.Models;
using RunTimeMapping.Models.MappingInterfaces;

namespace RunTimeMapping.Models
{
    public partial class UserMappingInterfaceImpl : IUserMappingInterface
    {
        public UserDto Map(User p1)
        {
            return p1 == null ? null : new UserDto()
            {
                Username = p1.Username,
                Age = p1.Age.ToString(),
                FullName = $"{p1.FirstName} {p1.LastName}",
                Address = p1.Address == null ? null : new AddressDto()
                {
                    City = p1.Address.City,
                    ZipCode = p1.Address.ZipCode,
                    Street = p1.Address.Street,
                    Apartment = p1.Address.Apartment
                }
            };
        }
    }
}
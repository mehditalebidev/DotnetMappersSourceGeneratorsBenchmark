using Mapster;

namespace RunTimeMapping.Models.MappingInterfaces;

[Mapper]
public interface IUserMappingInterface
{
    public UserDto Map(User user);
}
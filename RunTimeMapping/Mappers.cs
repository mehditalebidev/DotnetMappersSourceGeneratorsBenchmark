using System.ComponentModel;
using System.Globalization;
using AutoMapper;
using Mapster;
using Nelibur.ObjectMapper;
using RunTimeMapping.Models;
using RunTimeMapping.Models.MapperlyMappers;


namespace RunTimeMapping;

public class Mappers
{
    private readonly AutoMapper.Mapper _autoMapper;
    private readonly UserMappingInterfaceImpl _mapsterGenerated;
    private readonly UserMapper _mapperlyUserMapper;
    public Mappers()
    {
        //Automapper config
        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            cfg.CreateMap<Address, AddressDto>();
        });
        _autoMapper = new Mapper(config);
        
        //Mapster config
        TypeAdapterConfig<User, UserDto>
            .NewConfig()
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");

        //Tinymapper config
        TypeDescriptor.AddAttributes(typeof(User), new TypeConverterAttribute(typeof(UserConverter)));
        TinyMapper.Bind<User, UserDto>();
        TinyMapper.Bind<Address,AddressDto>();
        
        //MapsterGeneratedConfig
        _mapsterGenerated = new UserMappingInterfaceImpl();
        
        //MapperlyConfig
        _mapperlyUserMapper = new UserMapper();

    }

    public UserDto MapWithAutoMapper(User user)
    {
        var userDto = _autoMapper.Map<UserDto>(user);
        return userDto;
    }

    public UserDto MapWithMapster(User user)
    {
        var userDto = user.Adapt<UserDto>();
        return userDto;
    }
    
    public UserDto MapWithMapsterGenerated(User user)
    {
        var userDto = _mapsterGenerated.Map(user);
        return userDto;
    }
    
    public UserDto MapWithTinyMapper(User user)
    {
        var userDto = TinyMapper.Map<UserDto>(user);
        return userDto;
    }
    
    public UserDto InLineMapping(User user)
    {
        var userDto = new UserDto()
        {
            Address = new AddressDto()
            {
                Apartment = user.Address.Apartment,
                City = user.Address.City,
                Street = user.Address.Street,
                ZipCode = user.Address.ZipCode
            },
            Username = user.Username,
            FullName = $"{user.FirstName} {user.LastName}",
            Age = user.Age.ToString()
        };
        return userDto;
    }
    
    public UserDto MapWithMapperly(User user)
    {
        var userDto = _mapperlyUserMapper.Map(user);
        return userDto;
    }
}


public sealed class UserConverter : TypeConverter
{
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        return destinationType == typeof(UserDto);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        var user = (User)value;
        var result = new UserDto
        {
            Address = new AddressDto()
            {
                Apartment = user.Address.Apartment,
                City = user.Address.City,
                Street = user.Address.Street,
                ZipCode = user.Address.ZipCode
            },
            Username = user.Username,
            FullName = $"{user.FirstName} {user.LastName}",
            Age = user.Age.ToString()
        };
        return result;
    }
}


using RunTimeMapping;
using RunTimeMapping.Models;
using FluentAssertions;
using NUnit.Framework;

namespace RunTimeMappingTests;

public class TypeTests
{
    private Mappers _mappers;
    [SetUp]
    public void Setup()
    {
        _mappers = new Mappers();
    }

    [Test]
    public void InLineMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi",
            Address = new Address()
            {
                Apartment = "55",
                City = "LA",
                Street = "55th",
                ZipCode = "55921"
            },
            Age = 25,
            Password = "123",
            Username = "mehdi"
        };
        
        // Act
        var userDto = _mappers.InLineMapping(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Username = "mehdi",
            Address = new AddressDto()
            {
                Apartment = "55",
                City = "LA",
                Street = "55th",
                ZipCode = "55921"
            },
            FullName = "Mehdi Talebi",
            Age = "25"
        });
    }
    
    [Test]
    public void AutoMapperMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi",
            Address = new Address()
            {
                Apartment = "55",
                City = "LA",
                Street = "55th",
                ZipCode = "55921"
            },
            Age = 25,
            Password = "123",
            Username = "mehdi"
        };
        
        // Act
        var userDto = _mappers.MapWithAutoMapper(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Username = "mehdi",
            Address = new AddressDto()
            {
                Apartment = "55",
                City = "LA",
                Street = "55th",
                ZipCode = "55921"
            },
            FullName = "Mehdi Talebi",
            Age = "25"
        });
    }
    
    [Test]
    public void MapsterMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi",
            Address = new Address()
            {
                Apartment = "55",
                City = "LA",
                Street = "55th",
                ZipCode = "55921"
            },
            Age = 25,
            Password = "123",
            Username = "mehdi"
        };
        
        // Act
        var userDto = _mappers.MapWithMapster(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Username = "mehdi",
            Address = new AddressDto()
            {
                Apartment = "55",
                City = "LA",
                Street = "55th",
                ZipCode = "55921"
            },
            FullName = "Mehdi Talebi",
            Age = "25"
        });
    }
    
    [Test]
    public void MapsterGeneratedMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi",
            Address = new Address()
            {
                Apartment = "55",
                City = "LA",
                Street = "55th",
                ZipCode = "55921"
            },
            Age = 25,
            Password = "123",
            Username = "mehdi"
        };
        
        // Act
        var userDto = _mappers.MapWithMapsterGenerated(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Username = "mehdi",
            Address = new AddressDto()
            {
                Apartment = "55",
                City = "LA",
                Street = "55th",
                ZipCode = "55921"
            },
            FullName = "Mehdi Talebi",
            Age = "25"
        });
    }
    
    
    
    [Test]
    public void TinyMapperMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi",
            Address = new Address()
            {
                Apartment = "55",
                City = "LA",
                Street = "55th",
                ZipCode = "55921"
            },
            Age = 25,
            Password = "123",
            Username = "mehdi"
        };
        
        // Act
        var userDto = _mappers.MapWithTinyMapper(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Username = "mehdi",
            Address = new AddressDto()
            {
                Apartment = "55",
                City = "LA",
                Street = "55th",
                ZipCode = "55921"
            },
            FullName = "Mehdi Talebi",
            Age = "25"
        });
    }
    
    [Test]
    public void MapperlyMapping()
    {
        // Arrange
        var user = new User()
        {
            FirstName = "Mehdi",
            LastName = "Talebi",
            Address = new Address()
            {
                Apartment = "55",
                City = "LA",
                Street = "55th",
                ZipCode = "55921"
            },
            Age = 25,
            Password = "123",
            Username = "mehdi"
        };
        
        // Act
        var userDto = _mappers.MapWithMapperly(user);

        // Assert
        Assert.IsInstanceOf<UserDto>(userDto);
        userDto.Should().BeEquivalentTo(new UserDto()
        {
            Username = "mehdi",
            Address = new AddressDto()
            {
                Apartment = "55",
                City = "LA",
                Street = "55th",
                ZipCode = "55921"
            },
            FullName = "Mehdi Talebi",
            Age = "25"
        });
    }
}
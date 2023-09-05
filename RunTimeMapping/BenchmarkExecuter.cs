using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using RunTimeMapping.Models;

namespace RunTimeMapping;

[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[RPlotExporter]
[MemoryDiagnoser(false)]

public class BenchmarkExecuter
{
    private User? _user;
    private readonly Mappers _mappers;
    
    public BenchmarkExecuter()
    {
        _mappers = new Mappers();
    }
    
    [GlobalSetup]
    public void Setup()
    {
        _user = new User()
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
    }
    
    [Benchmark]
    public UserDto AutoMapper()
    {
        return _mappers.MapWithAutoMapper(_user);
    }

    [Benchmark] 
    public UserDto Mapster()
    {
        return _mappers.MapWithMapster(_user);
    }
    

    
    [Benchmark] 
    public UserDto TinyMapper()
    {
        return _mappers.MapWithTinyMapper(_user);
    }
    
    [Benchmark] 
    public UserDto InLine()
    {
        return _mappers.InLineMapping(_user);
    }
    
    [Benchmark] 
    public UserDto Mapster_Generated()
    {
        return _mappers.MapWithMapsterGenerated(_user);
    }
    
    [Benchmark] 
    public UserDto Mapperly_Generated()
    {
        return _mappers.MapWithMapperly(_user);
    }
   
}
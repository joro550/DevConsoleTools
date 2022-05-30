using Microsoft.Extensions.DependencyInjection;
using Spectre.Cli;

namespace CommandLine.Infrastructure;

public class TypeRegistrar : ITypeRegistrar
{
    private readonly IServiceCollection _builder;

    public TypeRegistrar(IServiceCollection builder) 
        => _builder = builder;

    public ITypeResolver Build() 
        => new TypeResolver(_builder.BuildServiceProvider());

    public void Register(Type service, Type implementation) 
        => _builder.AddSingleton(service, implementation);

    public void RegisterInstance(Type service, object implementation) 
        => _builder.AddSingleton(service, implementation);
}
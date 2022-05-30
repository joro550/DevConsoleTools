using Spectre.Cli;

namespace CommandLine.Infrastructure;

public sealed class TypeResolver : ITypeResolver, IDisposable
{
    private readonly IServiceProvider _provider;

    public TypeResolver(IServiceProvider provider) 
        => _provider = provider;

    public object Resolve(Type? type)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));

        var service = _provider.GetService(type);
        if (service == null)
            throw new Exception($"No service of type {type} is known");
        
        return service;
    }

    public void Dispose()
    {
        if (_provider is IDisposable disposable) 
            disposable.Dispose();
    }
}
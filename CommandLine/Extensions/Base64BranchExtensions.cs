using CommandLine.Encoding;
using Spectre.Cli;

namespace CommandLine.Extensions;

public static class Base64BranchExtensions
{
    public static IConfigurator BuildBase64Branch(this IConfigurator configurator)
    {
        configurator.AddBranch("base64", set =>
        {
            set.AddCommand<Base64Encode>("encode")
                .WithDescription("base64 encode string")
                .WithExample(new[] {"base64", "encode", "value"});

            set.AddCommand<Base64Decode>("decode")
                .WithDescription("base64 decode string")
                .WithExample(new[] {"base64", "decode", "value"});
        });
        return configurator;
    }
}
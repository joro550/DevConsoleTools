using CommandLine.StringManipulation;
using Spectre.Cli;

namespace CommandLine.Extensions;

public static class StringBranchExtensions
{
    public static IConfigurator BuildStringBranch(this IConfigurator configurator)
    {
        configurator.AddBranch("string", set =>
        {
            set.AddCommand<StringLowerCommand>("to-lower")
                .WithDescription("lower cases string")
                .WithExample(new[] {"string", "to-lower", "value"});
        
            set.AddCommand<StringUpperCommand>("to-upper")
                .WithDescription("upper cases string")
                .WithExample(new[] {"string", "to-upper", "value"});
        });
        return configurator;
    }
}
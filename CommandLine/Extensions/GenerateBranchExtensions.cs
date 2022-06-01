using CommandLine.Generators;
using Spectre.Cli;

namespace CommandLine.Extensions;

public static class GenerateBranchExtensions
{
    public static IConfigurator BuildGenerateBranch(this IConfigurator configurator)
    {
        configurator.AddBranch("generate", set =>
        {
            set.AddCommand<GenerateGuidCommand>("guid")
                .WithDescription("generate random guid")
                .WithExample(new[] {"generate", "guid", "--hyphens", "true", "--uppercase", "true"})
            
                .WithExample(new[] {"generate", "guid", "--hyphens", "true", "--uppercase", "true", "--amount", "10"})
                .WithExample(new[] {"generate", "guid", "-h", "true", "-u", "true", "-a", "10"})
                .WithExample(new[] {"generate", "guid"});;
        
            set.AddCommand<GenerateEmailCommand>("email")
                .WithDescription("generate random email")
                .WithExample(new[] {"generate", "email"})
                .WithExample(new[] {"generate", "email", "--amount", "10"});
        
            set.AddCommand<RandomNumberCommand>("number")
                .WithDescription("generate random number")
                .WithExample(new[] {"generate", "number", "--max", "100", "--min", "50"});
        
            set.AddCommand<LoremIpsumCommand>("lorem")
                .WithDescription("generate lorem ipsum")
                .WithExample(new[] {"generate", "lorem"});
        });
        return configurator;
    }
}
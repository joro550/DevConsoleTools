using Spectre.Cli;
using CommandLine.Encoding;
using CommandLine.Generators;
using CommandLine.StringManipulation;

var app = new CommandApp();

app.Configure(config =>
{
    config.ValidateExamples();
    
    config.AddCommand<GenerateGuidCommand>("gg")
        .WithDescription("generate random guid")
        .WithExample(new[] {"gg", "--hyphens", "true", "--uppercase", "true"})
        .WithExample(new[] {"gg", "-h", "true", "-u", "true"});
    
    config.AddBranch("generate", set =>
    {
        set.AddCommand<GenerateGuidCommand>("guid")
            .WithDescription("generate random guid")
            .WithExample(new[] {"generate", "guid", "--hyphens", "true", "--uppercase", "true"});
        
        set.AddCommand<GenerateEmailCommand>("email")
            .WithDescription("generate random email")
            .WithExample(new[] {"generate", "email"});
        
        set.AddCommand<RandomNumberCommand>("number")
            .WithDescription("generate random number")
            .WithExample(new[] {"generate", "number", "--max", "100", "--min", "50"});
        
        set.AddCommand<LoremIpsumCommand>("lorem")
            .WithDescription("generate lorem ipsum")
            .WithExample(new[] {"generate", "lorem"});
    });

    config.AddBranch("base64", set =>
    {
        set.AddCommand<Base64Encode>("encode")
            .WithDescription("base64 encode string")
            .WithExample(new[] {"base64", "encode", "value"});

        set.AddCommand<Base64Decode>("decode")
            .WithDescription("base64 decode string")
            .WithExample(new[] {"base64", "decode", "value"});
    });
    
    config.AddBranch("string", set =>
    {
        set.AddCommand<StringLowerCommand>("to-lower")
            .WithDescription("lower cases string")
            .WithExample(new[] {"string", "to-lower", "value"});
        
        set.AddCommand<StringUpperCommand>("to-upper")
            .WithDescription("upper cases string")
            .WithExample(new[] {"string", "to-upper", "value"});
    });
}); 

await app.RunAsync(args);
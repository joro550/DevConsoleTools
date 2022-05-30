using Spectre.Cli;
using CommandLine.Encoding;
using CommandLine.Generators;
using CommandLine.StringManipulation;

var app = new CommandApp();

app.Configure(config =>
{
    config.AddBranch("generate", set =>
    {
        set.AddCommand<GenerateGuidCommand>("guid")
            .WithDescription("generate random guid")
            .WithExample(args);
        
        set.AddCommand<GenerateEmailCommand>("email")
            .WithDescription("generate random guid")
            .WithExample(args);
        
        set.AddCommand<RandomNumberCommand>("number")
            .WithDescription("generate random number")
            .WithExample(args);
    });

    config.AddBranch("base64", set =>
    {
        set.AddCommand<Base64Encode>("encode")
            .WithDescription("base64 encode string")
            .WithExample(args);

        set.AddCommand<Base64Decode>("decode")
            .WithDescription("base64 decode string")
            .WithExample(args);
    });
    
    config.AddBranch("string", set =>
    {
        set.AddCommand<StringLowerCommand>("to-lower")
            .WithDescription("lower cases string")
            .WithExample(args);
        
        set.AddCommand<StringUpperCommand>("to-upper")
            .WithDescription("upper cases string")
            .WithExample(args);
    });
});

await app.RunAsync(args);
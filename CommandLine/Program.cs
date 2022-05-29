using CommandLine.Encoding;
using CommandLine.Generators;
using Spectre.Cli;

var app = new CommandApp();

app.Configure(config =>
{
    config.AddBranch("generate", set =>
    {
        set.AddCommand<GenerateGuidCommand>("guid")
            .WithExample(args);
    });

    config.AddBranch("base64", set =>
    {
        set.AddCommand<Base64Encode>("encode")
            .WithExample(args);

        set.AddCommand<Base64Decode>("decode")
            .WithExample(args);
    });
    
    
});

await app.RunAsync(args);
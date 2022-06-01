using Spectre.Cli;
using CommandLine.Git;
using CommandLine.Directory;
using CommandLine.Extensions;
using CommandLine.Generators;

var app = new CommandApp();

app.Configure(config =>
{
    config.ValidateExamples();
    
    config.AddCommand<GenerateGuidCommand>("gg")
        .WithDescription("generate random guid")
        .WithExample(new[] {"gg", "--hyphens", "true", "--uppercase", "true", "--amount", "10"})
        .WithExample(new[] {"gg", "-h", "true", "-u", "true", "-a", "10"})
        .WithExample(new[] {"gg"});

    config
        .BuildGenerateBranch()
        .BuildStringBranch()
        .BuildBase64Branch();
    
    config.AddCommand<CopyCurrentDirectoryCommand>("curdir")
        .WithDescription("copies current directory to clipboard");

    config.AddCommand<ListDirectoryCommand>("ls");
    // config.AddCommand<ChangeDirectoryCommand>("cd");
    
    // git stuff
    config.AddCommand<GitAddCommand>("ga")
        .WithDescription("git add .");
    
    config.AddCommand<GitCommitCommand>("gc")
        .WithDescription("git commit with message");
    
    config.AddCommand<GitPushCommand>("gp")
        .WithDescription("git push");
    
    config.AddCommand<GitBranchCommand>("gb")
        .WithDescription("git branch --set-upstream");
});

await app.RunAsync(args);
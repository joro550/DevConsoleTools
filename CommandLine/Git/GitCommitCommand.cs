using System.ComponentModel;
using CommandLine.Infrastructure;
using Spectre.Cli;
using Spectre.Console;
using ValidationResult = Spectre.Cli.ValidationResult;

namespace CommandLine.Git;

public class GitCommitCommand : AsyncCommand<GitCommitCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandOption("--message|-m"),
         Description("Commit message")]
        public string Message { get; set; } 
            = string.Empty;

        public override ValidationResult Validate()
        {
            return string.IsNullOrEmpty(Message)
                ? ValidationResult.Error("Message is required")
                : ValidationResult.Success();
        }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var batAsync = await $"git commit -m \"{settings.Message}\"".BatAsync();
        AnsiConsole.WriteLine(batAsync);
        return await Task.FromResult(1);
    }
}
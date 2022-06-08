using Spectre.Cli;
using Spectre.Console;
using CommandLine.Infrastructure;

namespace CommandLine.Git;

public class GitCloneCommand : AsyncCommand<GitCloneCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<Url>")] 
        public string Url { get; set; } = string.Empty;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var clone = await $"git clone {settings.Url}".BatAsync();
        AnsiConsole.WriteLine(clone);
        return await Task.FromResult(1);
    }
}
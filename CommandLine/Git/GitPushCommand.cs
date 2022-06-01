using CommandLine.Infrastructure;
using Spectre.Cli;
using Spectre.Console;

namespace CommandLine.Git;

public class GitPushCommand : AsyncCommand<GitPushCommand.Settings>
{
    public class Settings : CommandSettings
    {
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var batAsync = await "git push".BatAsync();
        AnsiConsole.WriteLine(batAsync);
        return await Task.FromResult(1);
    }
}
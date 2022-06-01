using CommandLine.Infrastructure;
using Spectre.Cli;
using Spectre.Console;

namespace CommandLine.Git;

public class GitAddCommand : AsyncCommand<GitAddCommand.Settings>
{
    public class Settings : CommandSettings
    {
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var result = await "git add --all -v".BatAsync();
        AnsiConsole.WriteLine(result);
        return await Task.FromResult(1);
    }
}
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
public class GitBranchCommand : AsyncCommand<GitBranchCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<Name>")] 
        public string Name { get; set; } = string.Empty;

        [CommandOption("--feature|-f")] 
        public bool Feature { get; set; } = false;
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var branchName = settings.Feature ? $"feature/{settings.Name}" : settings.Name;
        var branch = await $"git switch -c {branchName}".BatAsync();
        AnsiConsole.WriteLine(branch);
        var push = await $"git push --set-upstream origin {branchName}".BatAsync();
        AnsiConsole.WriteLine(push);
        return await Task.FromResult(1);
    }
}
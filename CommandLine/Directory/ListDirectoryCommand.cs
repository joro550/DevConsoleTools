using Spectre.Cli;
using Spectre.Console;

namespace CommandLine.Directory;

public class ListDirectoryCommand : AsyncCommand<ListDirectoryCommand.Settings>
{
    public class Settings : CommandSettings
    {
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var directory = System.IO.Directory.GetCurrentDirectory();
        var tree = new Tree(directory);
        
        
        foreach (var dir in System.IO.Directory.GetDirectories(directory)) 
            tree.AddNode($"[yellow][bold]{dir}[/][/]");

        foreach (var files in System.IO.Directory.GetFiles(directory)) 
            tree.AddNode(files);

        AnsiConsole.Write(tree);
        return await Task.FromResult(1);
    }
}
using Spectre.Cli;
using Spectre.Console;
using TextCopy;

namespace CommandLine.Directory;

public class CopyCurrentDirectoryCommand : AsyncCommand<CopyCurrentDirectoryCommand.Settings>
{
    public class Settings : CommandSettings
    {
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var directory = System.IO.Directory.GetCurrentDirectory();
        AnsiConsole.Write(directory);

        await ClipboardService.SetTextAsync(directory);
        return await Task.FromResult(1);
    }
}
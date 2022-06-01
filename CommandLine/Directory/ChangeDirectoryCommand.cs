using Spectre.Cli;
using Spectre.Console;
using CommandLine.Infrastructure;

namespace CommandLine.Directory;

public class ChangeDirectoryCommand : AsyncCommand<ChangeDirectoryCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandOption("--location|-l")]
        public string? Location { get; set; }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        string lastChoice;
        var choices = GetChoices(settings.Location 
                                 ?? System.IO.Directory.GetCurrentDirectory());
        
        var choice = lastChoice = AnsiConsole.Prompt(choices);
        if (string.Equals(choice, "here", StringComparison.CurrentCultureIgnoreCase))
        {
            System.IO.Directory.SetCurrentDirectory(settings.Location 
                                                    ?? System.IO.Directory.GetCurrentDirectory());
            return await Task.FromResult(1);
        }

        while (!string.Equals(choice, "here", StringComparison.CurrentCultureIgnoreCase))
        {
            choices = GetChoices(choice);
            lastChoice = new string(choice);
            choice = AnsiConsole.Prompt(choices);
        }

        var batAsync = await $"git add .".BatAsync();
        AnsiConsole.WriteLine(batAsync);
        
        return await Task.FromResult(1);
    }

    private static SelectionPrompt<string> GetChoices(string location)
    {
        var moreChoicesText = new SelectionPrompt<string>()
            .Title("[green]What directory[/]?")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more directories)[/]");

        moreChoicesText.AddChoice("Here");

        foreach (var dir in System.IO.Directory.GetDirectories(location))
            moreChoicesText.AddChoice(dir);
        
        
        return moreChoicesText;
    }
}
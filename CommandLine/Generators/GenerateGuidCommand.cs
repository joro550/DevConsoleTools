using Spectre.Cli;
using Spectre.Console;

namespace CommandLine.Generators;

public class GenerateGuidCommand : Command<GenerateGuidCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandOption("--hyphens|-h")] 
        public bool Hyphens { get; set; } = true;

        [CommandOption("--uppercase|-u")] 
        public bool Uppercase { get; set; } = false;
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var value = Guid.NewGuid().ToString(settings.Hyphens ? "N" : "D");
        AnsiConsole.WriteLine(settings.Uppercase ? value.ToUpper() : value.ToLower());
        return 1;
    }
}
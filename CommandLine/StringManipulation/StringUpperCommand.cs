using Spectre.Cli;
using Spectre.Console;

namespace CommandLine.StringManipulation;

public class StringUpperCommand: Command<StringUpperCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "[Value]")]
        public string Value { get; set; } = string.Empty;
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        AnsiConsole.WriteLine(settings.Value.ToUpper());
        return 0;
    }
}
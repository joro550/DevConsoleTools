using System.ComponentModel;
using Spectre.Cli;
using Spectre.Console;

namespace CommandLine.Generators;

public class LoremIpsumCommand : Command<LoremIpsumCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [DefaultValue(3), 
         CommandOption("--word-count")]
        public int WordCount { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var enumerable = string.Join(" ", Faker.Lorem.Words(settings.WordCount));
        AnsiConsole.WriteLine(enumerable);
        return 1;
    }
}
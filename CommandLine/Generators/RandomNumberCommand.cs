using Spectre.Cli;
using Spectre.Console;

namespace CommandLine.Generators;

public class RandomNumberCommand : Command<RandomNumberCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandOption("--min")] 
        public long? Min { get; set; } = null;
        
        [CommandOption("--max")]
        public long? Max { get; set; } = null;
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var min = settings.Min ?? 0;
        var max = settings.Max ?? long.MaxValue;
        AnsiConsole.WriteLine(Faker.RandomNumber.Next(min, max));
        return 1;
    }
}
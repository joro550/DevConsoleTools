using System.ComponentModel;
using Spectre.Cli;
using Spectre.Console;

namespace CommandLine.Generators;

public class RandomNumberCommand : Command<RandomNumberCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandOption("--min"), 
         DefaultValue(0)] 
        public long Min { get; set; }
        
        [CommandOption("--max"), 
         DefaultValue(long.MaxValue)]
        public long Max { get; set; } 
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        AnsiConsole.WriteLine(Faker.RandomNumber.Next(settings.Min, settings.Max));
        return 1;
    }
}
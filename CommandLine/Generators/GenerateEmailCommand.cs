using Spectre.Cli;
using Spectre.Console;

namespace CommandLine.Generators;

public class GenerateEmailCommand : Command<GenerateEmailCommand.Settings>
{
    public class Settings : CommandSettings
    {
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        AnsiConsole.WriteLine(Faker.Internet.Email());
        return 1;
    }
}
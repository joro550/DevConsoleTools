using System.ComponentModel;
using Spectre.Cli;
using Spectre.Console;

namespace CommandLine.Generators;

public class GenerateEmailCommand : Command<GenerateEmailCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandOption("--amount"),
            DefaultValue(1)]
        public int Amount { get; set; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var table = new Table();
        table.AddColumn(new TableColumn("Email").Centered());
        
        foreach (var email in Enumerable.Range(0, settings.Amount)
                     .Select(_ => Faker.Internet.Email()))
        {
            table.AddRow(email);
        }

        AnsiConsole.Render(table);
        return 1;
    }
}
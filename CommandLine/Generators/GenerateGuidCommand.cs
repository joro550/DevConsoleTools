using System.ComponentModel;
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
        
        [CommandOption("--amount|-a"),
         Description("Amount of guids to generate"),
         DefaultValue(1)]
        public int Amount { get; set; }
        
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        if (settings.Amount > 1)
        {
            var values = Enumerable.Range(0, settings.Amount)
                .Select(_ => Guid.NewGuid().ToString(settings.Hyphens ? "N" : "D"));
            var table = new Table();
            table.AddColumn(new TableColumn("Guid").Centered());
        
            foreach (var value in values)
            {
                table.AddRow(settings.Uppercase ? value.ToUpper() : value.ToLower());
            }
            AnsiConsole.Write(table);
        }
        else
        {
            AnsiConsole.Write(Guid.NewGuid().ToString(settings.Hyphens ? "N" : "D"));
        }
        
        return 1;
    }
}
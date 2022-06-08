using System.ComponentModel;
using Spectre.Cli;
using Spectre.Console;
using TextCopy;

namespace CommandLine.Generators;

public class GenerateGuidCommand : AsyncCommand<GenerateGuidCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandOption("--hyphens|-h"),
         Description("Determines whether the guids should have hyphens")] 
        public bool Hyphens { get; set; } = true;

        [CommandOption("--uppercase|-u"),
         Description("Determines whether the guids should be uppercased")] 
        public bool Uppercase { get; set; } = false;
        
        [CommandOption("--amount|-a"),
         Description("Amount of guids to generate"),
         DefaultValue(1)]
        public int Amount { get; set; }
        
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var format = Guid.NewGuid().ToString(settings.Hyphens ? "N" : "D");
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
            AnsiConsole.Write(format);
            await ClipboardService.SetTextAsync(format);
        }
        
        return 1;
    }
}
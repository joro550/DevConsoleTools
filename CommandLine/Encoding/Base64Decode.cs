using Spectre.Cli;
using Spectre.Console;
using System.ComponentModel.DataAnnotations;

namespace CommandLine.Encoding;

public class Base64Decode : Command<Base64Decode.Settings>
{
    public class Settings : CommandSettings
    {
        [Required, CommandArgument(0, "[Value]")]        
        public string Value { get; set; } = string.Empty;
    }
    
    private static string Decode(string originalString)
    {
        var bytes = Convert.FromBase64String(originalString);
        return System.Text.Encoding.UTF8.GetString(bytes);
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        AnsiConsole.WriteLine(Decode(settings.Value));
        return 1;
    }
}
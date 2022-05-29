using Spectre.Cli;
using Spectre.Console;
using System.ComponentModel.DataAnnotations;

namespace CommandLine.Encoding;
public class Base64Encode: Command<Base64Encode.Settings>
{
    public class Settings : CommandSettings
    {
        [Required, CommandArgument(0, "[Value]")]
        public string Value { get; set; } = string.Empty;
    }
    
    private static string Encode(string originalString)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(originalString);
        return Convert.ToBase64String(bytes);
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        AnsiConsole.WriteLine(Encode(settings.Value));
        return 1;
    }
}
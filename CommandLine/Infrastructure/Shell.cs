using System.Diagnostics;

namespace CommandLine.Infrastructure;

public static class Shell
{
    public static string Bash(this string cmd) 
        => Run("/bin/bash", $"-c \"{cmd.Replace("\"", "\\\"")}\"");

    public static string Bat(this string cmd) 
        => Run("cmd.exe", $"/c \"{cmd.Replace("\"", "\\\"")}\"");

    public static async Task<string> BatAsync(this string cmd) 
        => await RunAsync("cmd.exe", $"/c \"{cmd.Replace("\"", "\\\"")}\"");

    private static string Run (string filename, string arguments)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = filename,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = false,
            }
        };
        process.Start();
        var result = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        return result;
    }

    private static async Task<string> RunAsync (string filename, string arguments)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = filename,
                Arguments = arguments,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = false,
            }
        };
        process.Start();
        var result = await process.StandardOutput.ReadToEndAsync();
        await process.WaitForExitAsync();
        return result;
    }
}
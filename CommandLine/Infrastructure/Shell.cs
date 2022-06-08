using System.Diagnostics;
using System.Management.Automation.Runspaces;

namespace CommandLine.Infrastructure;

public static class Shell
{
    public static string Bash(this string cmd) 
        => Run("/bin/bash", $"-c \"{cmd.Replace("\"", "\\\"")}\"");

    public static async Task<string> BatAsync(this string cmd) 
        => await RunAsync("cmd.exe", $"/c {cmd}");

    public static async Task<string> PowershellAsync(this string cmd) 
        => await Run2("cmd.exe", $"/c {cmd}");

    private static async Task<string> Run2 (string filename, string arguments)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = filename,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
        process.Start();
        await process.StandardInput.WriteLineAsync(arguments);
        // var result = await process.StandardOutput.ReadToEndAsync();
        await process.WaitForExitAsync();
        return string.Empty;
    }

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
                CreateNoWindow = true,
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
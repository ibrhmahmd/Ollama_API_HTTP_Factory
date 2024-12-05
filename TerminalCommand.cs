using System.Diagnostics;

public class TerminalCommand
{
    public static string ExecuteCommand(string command)
    {
        try
        {
            // Create a new process
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // Use "bash" or the actual executable on Linux/macOS
                    Arguments = $"/C {command}", // "/C" for cmd to execute and terminate
                    RedirectStandardOutput = true, // Capture output
                    RedirectStandardError = true, // Capture errors
                    UseShellExecute = false, // Required for redirection
                    CreateNoWindow = true // No GUI window
                }
            };

            process.Start(); // Start the process

            string output = process.StandardOutput.ReadToEnd(); // Read the output
            string error = process.StandardError.ReadToEnd(); // Read errors

            process.WaitForExit(); // Wait for the process to finish

            return string.IsNullOrEmpty(error) ? output : $"Error: {error}";
        }
        catch (Exception ex)
        {
            return $"Exception: {ex.Message}";
        }
    }
}

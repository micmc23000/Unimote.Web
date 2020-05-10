using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main()
        {
            string program = "test2.py";
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), program);
            string compilerPath = @"python";
            string args = "Michael";

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo(compilerPath, $"{fileName} {args}")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                }
            };
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            Console.Write(output);
            process.WaitForExit();

        }
    }
}

namespace ConsoleAppTest
{
	using System;
	using System.Diagnostics;
	using System.IO;
	class PythonCaller
	{
		readonly string compilerPath = "python";
		readonly string program = "IrCommandCall.py";

		public string Execute(string remote)
		{
			string fileName = Path.Combine(Directory.GetCurrentDirectory(), program);

			Process process = new Process
			{
				StartInfo = new ProcessStartInfo(compilerPath, $"{fileName} {remote}")
				{
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = false,
				}
			};
			process.Start();

			string output = process.StandardOutput.ReadToEnd();
			process.WaitForExit();

			return output;
		}
	}
}

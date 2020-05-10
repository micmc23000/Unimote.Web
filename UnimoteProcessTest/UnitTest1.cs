namespace UnimoteProcessTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Security;
    [TestClass]
    public class PythonProcessTest
    {
        [TestMethod]
        public void TestProcessNotepadCall()
        {
            string fileName = "notepad.exe";
            string argument = "";
            string userName = "";
            SecureString password = new SecureString();
            string domain = "";
            Process.Start(fileName);
            //, argument, userName, password, domain);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestPython()
        {

            var expectedOutput = "Python C# Test"+Environment.NewLine;
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test2.py");
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

            Assert.AreEqual(output, expectedOutput);
        }
    }
}

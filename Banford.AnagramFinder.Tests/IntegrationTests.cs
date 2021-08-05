using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Xunit;

namespace Banford.AnagramFinder.Tests
{
    public class IntegrationTests
    {
        protected Process StartApplication()
        {
            var programLocation = Assembly.GetAssembly(typeof(AnagramFinder))?.Location;
            var executablePath = Path.GetDirectoryName(programLocation);

            var processStartInfo = new ProcessStartInfo
            {
                FileName = executablePath + @"\Banford.AnagramFinder.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };

            return Process.Start(processStartInfo);
        }
        
        [Fact]
        public void ProgramShouldRun()
        {
            // Arrange
            var process = StartApplication();

            // Act
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // Assert
            Assert.Contains("Starting AnagramFinder...", output);
        }
    }
}
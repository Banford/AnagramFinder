using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Banford.AnagramFinder.Tests
{
    public class IntegrationTests
    {
        private static Process StartApplication(string args = "")
        {
            var programLocation = Assembly.GetAssembly(typeof(AnagramFinder))?.Location;
            var executablePath = Path.GetDirectoryName(programLocation);

            var processStartInfo = new ProcessStartInfo
            {
                FileName = executablePath + @"\Banford.AnagramFinder.exe",
                Arguments = args,
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
        
        [Fact]
        public void ProgramShouldProduceCorrectOutput_WithExampleInputOne()
        {
            // Arrange
            const string testFile = "../../../data/example1.txt";
            var process = StartApplication(testFile);
            var output = new List<string>();

            // Act
            while (!process.StandardOutput.EndOfStream)
            {
                output.Add(process.StandardOutput.ReadLine());
            }
            process.WaitForExit();

            // Assert
            Assert.Equal("abc,bac,cba", output[1]);
            Assert.Equal("fun,unf", output[2]);
        }
        
        [Fact]
        public void ProgramShouldProduceCorrectOutput_WithExampleInputTwo()
        {
            // Arrange
            const string testFile = "../../../data/example2.txt";
            var process = StartApplication(testFile);
            var output = new List<string>();

            // Act
            while (!process.StandardOutput.EndOfStream)
            {
                output.Add(process.StandardOutput.ReadLine());
            }
            process.WaitForExit();

            // Assert
            Assert.Equal("ab,ba", output[1]);
            Assert.Equal("pathophysiological,physiopathological", output.Last());
        }
        
        [Fact]
        public void ProgramShouldProduceCorrectOutput_WithInvalidFilePath()
        {
            // Arrange
            const string testFile = "../../../data/does-not-exist.txt";
            var process = StartApplication(testFile);
            var output = new List<string>();

            // Act
            while (!process.StandardOutput.EndOfStream)
            {
                output.Add(process.StandardOutput.ReadLine());
            }
            process.WaitForExit();

            // Assert
            Assert.Contains("File did not exist", output[1]);
        }
    }
}
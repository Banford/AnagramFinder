using System;
using System.IO;
using Serilog;

namespace Banford.AnagramFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            
            Log.Information("Starting AnagramFinder...");
            
            if (args.Length != 1)
            {
                Log.Information("Wrong number of arguments provided.");
                Console.Write("Please provide a single file path as the only argument to this program.");
                return;
            }

            var fileName = args[0];

            if (!File.Exists(fileName))
            {
                Log.Information("File did not exist.");
                Console.WriteLine("The file you tried to process does not exist. Please check and try again.");
                return;
            }

            try
            {
                Log.Debug("Processing {A}", fileName);
                AnagramFileProcessor.Process(fileName);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "There was an error processing the input file.");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
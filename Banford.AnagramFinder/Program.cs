namespace Banford.AnagramFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = args[0];

            AnagramFileProcessor.Process(fileName);
        }
    }
}